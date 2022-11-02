using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heater : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject heart;
    [SerializeField] private Animator animator;

    public float range = 3;
    int max_dist = 3;

    Quaternion rightAngle;
    Quaternion leftAngle;
    Quaternion centerAngle;

    private GameObject task;
    private int hour = 1; 
    private int minute = 5;
    private string taskname = "Heater";
    private string tasktitle = "Heater";
    private string taskdescription = "Idz wylacz farelke!";

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

    public void InnitTask(){
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().CreateSMS("Taskinnit","Oskar [DEA]","Idz wylacz farelke.");
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
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().CreateSMS("TaskComplete","Printer Task Complete","Oskar: Dobrze przypierdolic czasem tez trzeba XD");
        DestroyTask();
    }

    private void TaskFailed(){
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().CreateSMS("TaskFaile","Printer Task Failed","Oskar: Wiecej sily kolego. Pokazac ci jak sie to robi?");
        DestroyTask();   
    }

    private void DestroyTask(){
        Destroy(task);
        QuestActive = false;
    }

    private void AccessObject(){
        //if(isNear(2, player, heart)) if (Input.GetKeyDown(KeyCode.E))
        if(isNear(4,player,heart)){
            if( Input.GetKeyDown(KeyCode.E)){
                animator.SetTrigger("Printer");
            }
        }
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
            }
        }

            if (Physics.Raycast(RayLeft, out hit, range))
        {
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true )
            {
                if(QuestActive) AccessObject();
            }
        }

            if (Physics.Raycast(RayRight, out hit, range))
        {
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true )
            {
                if(QuestActive) AccessObject();
            }
        }

    }

}