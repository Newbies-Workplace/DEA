using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coffee : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject indicator;
    [SerializeField] private bool indicator_ison = false;
    [SerializeField] private TMP_Text machine_sms;
    [SerializeField] private TMP_Text machine_name;

    Ray RayForward;
    Ray RayLeft;
    Ray RayRight;

    public float range = 2;
    int max_dist = 2;
    Quaternion rightAngle;
    Quaternion leftAngle;
    Quaternion centerAngle;

    //need for task
    private GameObject task;
    private int hour = 1; 
    private int minute = 15;
    private TaskTimer tasktimer;
    private ThirdPersonController Player;
    private SmsManager sms;
    private string taskname = "Coffee";
    private string tasktitle = "Coffee";

    //task check variables
    public bool TimesUp = false;
    public bool isDone = false;
    public bool QuestActive;
    public static int num;

    void Start(){
        Player = GameObject.Find("Player").GetComponent<ThirdPersonController>();
        sms = GameObject.Find("Sms Manager").GetComponent<SmsManager>();
        leftAngle = Quaternion.Euler(20,30,0);
        rightAngle = Quaternion.Euler(20,-30,0);
        centerAngle = Quaternion.Euler(20,0,0);
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
        num = Random.Range(0,4);
        sms.TaskQueue("Taskinnit",CoffeeLines.textName[num],CoffeeLines.textInit[num]);
        QuestActive = true;
        isDone = false;
        task = GameObject.Find("Task Manager").GetComponent<TaskManager>().CreateTaskOnList(taskname,tasktitle,CoffeeLines.textDescription[num]);
        machine_name.text = CoffeeLines.textName[num];
        machine_sms.text = CoffeeLines.textDescription[num];
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
        sms.TaskQueue("TaskComplete","Coffee Task Complete",CoffeeLines.textWon[num]);
        DestroyTask();
    }

    private void TaskFailed(){
        ExitTask();
        sms.TaskQueue("TaskFailed","Coffee Task Failed",CoffeeLines.textLost[num]);
        StaticClass.Grade--;
        DestroyTask();   
    }

    private void DestroyTask(){
        Destroy(task);
        QuestActive = false;
    }
 
    private void ExitTask(){
        if(Panel.activeSelf) Panel.SetActive(false);
        WeekStateManager.Instance.CoffeeDone();
        PlayerStateManager.Instance.UpdateState(PlayerState.FreeLook);
    }

    private void AccessObject(){
        if(isNear(4, player, heart)){
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