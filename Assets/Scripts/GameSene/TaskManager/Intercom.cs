using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intercom : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject Panel;

    [SerializeField] private TMP_Text title;
    [SerializeField] private GameObject indicator;
    [SerializeField] private bool indicator_ison = false;

    public float range = 3;
    int max_dist = 3;
    Ray RayForward;
    Ray RayLeft;
    Ray RayRight;
    Quaternion rightAngle;
    Quaternion leftAngle;
    Quaternion centerAngle;

    //need for task
    private GameObject task;
    private int hour = 0; 
    private int minute = 50;
    private string taskname = "Intercom";
    private string tasktitle = "Intercom";

    private TaskTimer tasktimer;
    private ThirdPersonController Player;
    private SmsManager sms;
    [SerializeField] private IntercomTask InterTask;

    //task check variables
    public bool TimesUp = false;
    public bool isDone = false;
    public bool QuestActive = false;
    private int num;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<ThirdPersonController>();
        sms = GameObject.Find("Sms Manager").GetComponent<SmsManager>();
        leftAngle = Quaternion.Euler(10,30,0);
        rightAngle = Quaternion.Euler(10,-30,0);
        centerAngle = Quaternion.Euler(10,0,0);
    }

    private bool isNear(int max_dist, GameObject target, GameObject heart){
        float distance = Vector3.Distance(heart.transform.position, target.transform.position);
        if (distance > max_dist) return false;
        return true;
    }

    private void DisablePlayer(){
        PlayerStateManager.Instance.UpdateState(PlayerState.UI);
    }

    public void InnitTask(){
        num = Random.Range(0,2);
        title.text = InterLines.taskWho[num];
        sms.TaskQueue("Taskinnit",InterLines.textName[num],InterLines.textInit[num]);
        QuestActive = true;
        isDone = false;
        InterTask.Reset();
        task = GameObject.Find("Task Manager").GetComponent<TaskManager>().CreateTaskOnList(taskname,tasktitle,InterLines.textDescription[num]);
        tasktimer = task.transform.Find("title").Find("Time").GetComponent<TaskTimer>();
        tasktimer.hour = hour;
        tasktimer.minute = minute;
        tasktimer.isRunning = true;

    }

    private void CheckTaskStatus(){
        if(tasktimer.TimesUp && QuestActive) TaskFailed();
        if(isDone && QuestActive) TaskComplete();
    }

    private void TaskComplete(){
        ExitTask();
        sms.TaskQueue("TaskComplete","Intercom Task Complete",InterLines.textWon[num]);
        DestroyTask();
    }

    private void TaskFailed(){
        ExitTask();
        sms.TaskQueue("TaskFaile","Intercom Task Failed",InterLines.textLost[num]);
        StaticClass.Grade--;
        DestroyTask();   
    }

    private void ExitTask(){
        if(Panel.activeSelf){
            Panel.SetActive(false);
            WeekStateManager.Instance.IntercomDone();
            PlayerStateManager.Instance.UpdateState(PlayerState.FreeLook);
        }
    }

    private void DestroyTask(){
        Destroy(task);
        QuestActive = false;
    }

    private void AccessObject(){
        if(isNear(2, player, heart)){
            if (Input.GetKeyDown(KeyCode.E)){ 
                if(Panel != null){ 
                    Panel.SetActive(true);
                    DisablePlayer();
                }
            }
        }
    }

    private void DrawRayCast(){
        Vector3 forward = centerAngle*Vector3.forward;
        Vector3 left = leftAngle*Vector3.forward;
        Vector3 right = rightAngle*Vector3.forward;
        RayForward = new Ray(transform.position, transform.TransformDirection(forward * range));
        RayLeft = new Ray(transform.position, transform.TransformDirection(left * range));
        RayRight = new Ray(transform.position, transform.TransformDirection(right * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(forward * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(left * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(right * range));
    }


    void Update()
    {
        indicator_ison = false;
        DrawRayCast();

        if (Physics.Raycast(RayForward, out RaycastHit hit, range)){
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true ){ 
                if(QuestActive) AccessObject();
                indicator_ison = true;
            }
        }

        if (Physics.Raycast(RayLeft, out hit, range)){
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true ){
                if(QuestActive) AccessObject();
                indicator_ison = true;
            }
        }

        if (Physics.Raycast(RayRight, out hit, range)){
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true ){
                if(QuestActive) AccessObject();
                indicator_ison = true;
            }
        }

        if(QuestActive) CheckTaskStatus();
        if(QuestActive) indicator.SetActive(indicator_ison);
        if(!QuestActive) indicator.SetActive(false);
        if(QuestActive && Panel.activeSelf == true) indicator.SetActive(false);
    }
}