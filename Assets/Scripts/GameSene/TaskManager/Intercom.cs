using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercom : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject Panel;

    public float range = 3;
    int max_dist = 3;

    Quaternion rightAngle;
    Quaternion leftAngle;
    Quaternion centerAngle;

    //need for task
    private GameObject task;
    private int hour = 0; 
    private int minute = 5;
    private string taskname = "Intercom";
    private string tasktitle = "Intercom";
    private string taskdescription = "Go to the intercom and decide about opening doors";

    //task check variables
    public bool TimesUp = false;
    public bool isDone = false;
    public bool QuestActive = false;

    void Start()
    {
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
        if(Panel.activeSelf){
            GameObject.Find("Player").transform.Find("Third Person Player").GetComponent<ThirdPersonController>().can_move = false;
            GameObject.Find("Player").transform.Find("Third Person Player").GetComponent<ThirdPersonController>().can_move_camera = false;
        }else{
            GameObject.Find("Player").transform.Find("Third Person Player").GetComponent<ThirdPersonController>().can_move = true;
            GameObject.Find("Player").transform.Find("Third Person Player").GetComponent<ThirdPersonController>().can_move_camera = true;
        }
    }

    public void InnitTask(){
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().CreateSMS("Taskinnit","Wojtek [DEA]","When the courier arrives, open the door for him.");
        QuestActive = true;
        task = GameObject.Find("Task Manager").GetComponent<TaskManager>().CreateTaskOnList(taskname,tasktitle,taskdescription);
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
        Panel.SetActive(false);
        DisablePlayer();
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().CreateSMS("TaskComplete","Intercom Task Complete","Wojtek: Dzieki, jakos mi sie nie chcialo wstawac XD");
        DestroyTask();
    }

    private void TaskFailed(){
        Panel.SetActive(false);
        DisablePlayer();
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().CreateSMS("TaskFaile","Intercom Task Failed","Wojtek: Masz awizo i teraz sam na rowerze jedz po paczke.");
        DestroyTask();   
    }

    private void DestroyTask(){
        Destroy(task);
        QuestActive = false;
    }

    private void AccessObject(){
        if(isNear(2, player, heart)) if (Input.GetKeyDown(KeyCode.E)) if(Panel != null) Panel.SetActive(true);
    }

    void Update()
    {
        if(QuestActive) CheckTaskStatus();

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
                // if(!isDone) AccessObject();
            }
        }

            if (Physics.Raycast(RayLeft, out hit, range))
        {
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true )
            {
                if(QuestActive) AccessObject();
                DisablePlayer();
                // if(!isDone) AccessObject();
            }
        }

            if (Physics.Raycast(RayRight, out hit, range))
        {
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true )
            {
                if(QuestActive) AccessObject();
                DisablePlayer();
                // if(!isDone) AccessObject();
            }
        }

    }
}