using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject indicator;
    [SerializeField] private bool indicator_ison = false;

    public float range = 2;
    int max_dist = 2;
    Quaternion rightAngle;
    Quaternion leftAngle;
    Quaternion centerAngle;

    //need for task
    private GameObject task;
    private int hour = 1; 
    private int minute = 15;
    private string taskname = "Coffee";
    private string tasktitle = "Coffee";

    //task check variables
    public bool TimesUp = false;
    public bool isDone = false;
    public bool QuestActive;
    public static int num;

    void Start(){
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
        if(Panel.activeSelf){
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
        num = Random.Range(0,4);
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().TaskQueue("Taskinnit",CoffeeLines.textName[num],CoffeeLines.textInit[num]);
        QuestActive = true;
        task = GameObject.Find("Task Manager").GetComponent<TaskManager>().CreateTaskOnList(taskname,tasktitle,CoffeeLines.textDescription[num]);
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
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().TaskQueue("TaskComplete","Coffee Task Complete",CoffeeLines.textWon[num]);
        DestroyTask();
    }

    private void TaskFailed(){
        Panel.SetActive(false);
        DisablePlayer();
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().TaskQueue("TaskFailed","Coffee Task Failed",CoffeeLines.textLost[num]);
        StaticClass.Grade--;
        DestroyTask();   
    }

    private void DestroyTask(){
        Destroy(task);
        QuestActive = false;
    }

    private void AccessObject(){
        DisablePlayer();
        if(isNear(4, player, heart)) if (Input.GetKeyDown(KeyCode.E)) if(Panel != null) Panel.SetActive(true);
    }


    void Update()
    {
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
                indicator_ison = true;
            }
        }

            if (Physics.Raycast(RayLeft, out hit, range))
        {
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true )
            {
                if(QuestActive) AccessObject();
                indicator_ison = true;
            }
        }

            if (Physics.Raycast(RayRight, out hit, range))
        {
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true )
            {
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