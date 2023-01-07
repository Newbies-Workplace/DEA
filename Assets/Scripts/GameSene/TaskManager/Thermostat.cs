using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermostat : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject ThermoPanel;
    [SerializeField] private GameObject indicator;
    [SerializeField] private bool indicator_ison = false;

    public float range = 4;
    int max_dist = 4;

    Ray RayForward;
    Ray RayLeft;
    Ray RayRight;

    Quaternion rightAngle;
    Quaternion leftAngle;
    Quaternion centerAngle;

    //need for task
    private GameObject task;
    private int hour = 1; 
    private int minute = 35;
    private string taskname = "Thermostatic";
    private string tasktitle = "Thermostat";

    //task check variables
    public bool TimesUp = false;
    public static bool isDone = false;
    private ThirdPersonController Player;
    private TaskTimer tasktimer;
    private SmsManager sms;
    public static int TaskGoal = 30;
    public bool QuestActive;
    private int num;

    void Start(){
        Player = GameObject.Find("Player").GetComponent<ThirdPersonController>();
        sms = GameObject.Find("Sms Manager").GetComponent<SmsManager>();
        ThermoHandler.ThermoStatValue = 21;
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
        num = Random.Range(0,3);
        TaskGoal = ThermoLines.taskTemp[num];
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().TaskQueue("Taskinnit",ThermoLines.textName[num],ThermoLines.textInit[num]);
        QuestActive = true;
        isDone = false;
        task = GameObject.Find("Task Manager").GetComponent<TaskManager>().CreateTaskOnList(taskname,tasktitle,ThermoLines.textDescription[num]);
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
        sms.TaskQueue("TaskComplete","Intercom Task Complete",ThermoLines.textWon[num]);
        DestroyTask();
    }

    private void TaskFailed(){
        ExitTask();
        sms.TaskQueue("TaskFailed","Thermostat Task Failed",ThermoLines.textLost[num]);
        StaticClass.Grade--;
        DestroyTask();   
    }

    private void DestroyTask(){
        WeekStateManager.Instance.ThermostaticDone();
        Destroy(task);
        QuestActive = false;
    }

    private void AccessObject(){
        if(isNear(4, player, heart)){
            if (Input.GetKeyDown(KeyCode.E)){ 
                if(ThermoPanel != null){ 
                    ThermoPanel.SetActive(true);
                    DisablePlayer();
                    Debug.Log("hello");
                }
            }
        }
    }

    private void ExitTask(){
        if(ThermoPanel.activeSelf) ThermoPanel.SetActive(false);
        PlayerStateManager.Instance.UpdateState(PlayerState.FreeLook);   
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
        if(QuestActive && ThermoPanel.activeSelf == true) indicator.SetActive(false);
    }
}