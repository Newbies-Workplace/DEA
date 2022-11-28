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
    public static int TaskGoal = 30;
    public bool QuestActive;
    private int num;

    void Start(){
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
        if(ThermoPanel.activeSelf){
            GameObject.Find("Player").GetComponent<ThirdPersonController>().can_move = false;
            GameObject.Find("Player").GetComponent<ThirdPersonController>().can_move_camera = false;
            ThirdPersonController.isVisibleCursor = true;
        }else{
            GameObject.Find("Player").GetComponent<ThirdPersonController>().can_move = true;
            GameObject.Find("Player").GetComponent<ThirdPersonController>().can_move_camera = true;
            ThirdPersonController.isVisibleCursor = false;
        }
    }


    public void InnitTask(){
        num = Random.Range(0,3);
        TaskGoal = ThermoLines.taskTemp[num];
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().TaskQueue("Taskinnit",ThermoLines.textName[num],ThermoLines.textInit[num]);
        QuestActive = true;
        task = GameObject.Find("Task Manager").GetComponent<TaskManager>().CreateTaskOnList(taskname,tasktitle,ThermoLines.textDescription[num]);
        task.transform.Find("title").Find("Timer").GetComponent<TaskTimer>().hour = hour;
        task.transform.Find("title").Find("Timer").GetComponent<TaskTimer>().minute = minute;
        task.transform.Find("title").Find("Timer").GetComponent<TaskTimer>().isRunning = true;
    }

    private void CheckTaskStatus(){
        TimesUp = task.transform.Find("title").Find("Timer").GetComponent<TaskTimer>().TimesUp;
        if(TimesUp && QuestActive) TaskFailed();
        if(isDone && QuestActive) TaskComplete();
    }

    private void TaskComplete(){
        ThermoPanel.SetActive(false);
        DisablePlayer();
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().TaskQueue("TaskComplete","Intercom Task Complete",ThermoLines.textWon[num]);
        DestroyTask();
    }

    private void TaskFailed(){
        ThermoPanel.SetActive(false);
        DisablePlayer();
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().TaskQueue("TaskFailed","Thermostat Task Failed",ThermoLines.textLost[num]);
        DestroyTask();   
    }

    private void DestroyTask(){
        Destroy(task);
        QuestActive = false;
    }

    private void AccessObject(){
        DisablePlayer();
        if(isNear(4, player, heart)) if (Input.GetKeyDown(KeyCode.E)) if(ThermoPanel != null) ThermoPanel.SetActive(true);
    }


    void Update()
    {
        if(QuestActive) CheckTaskStatus();
    
        indicator_ison = false;
        Vector3 forward = centerAngle*Vector3.forward;
        Vector3 left = leftAngle*Vector3.forward;
        Vector3 right = rightAngle*Vector3.forward;
        Ray RayForward = new Ray(transform.position, transform.TransformDirection(forward * range));
        Ray RayLeft = new Ray(transform.position, transform.TransformDirection(left * range));
        Ray RayRight = new Ray(transform.position, transform.TransformDirection(right * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(forward * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(left * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(right * range));
        
        if (Physics.Raycast(RayForward, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true )
            {
                if(QuestActive) AccessObject();
                DisablePlayer();
                indicator_ison = true;
                // if(!isDone) AccessObject();
            }
        }

        if (Physics.Raycast(RayLeft, out hit, range))
        {
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true )
            {
                if(QuestActive) AccessObject();
                DisablePlayer();
                indicator_ison = true;
                // if(!isDone) AccessObject();
            }
        }

        if (Physics.Raycast(RayRight, out hit, range))
        {
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true )
            {
                if(QuestActive) AccessObject();
                DisablePlayer();
                indicator_ison = true;
                // if(!isDone) AccessObject();
            }
        }
        if(QuestActive) indicator.SetActive(indicator_ison);
        if(!QuestActive) indicator.SetActive(false);
        if(QuestActive && ThermoPanel.activeSelf == true) indicator.SetActive(false);

    }
}