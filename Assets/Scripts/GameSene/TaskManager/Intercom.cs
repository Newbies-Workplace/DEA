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

    Quaternion rightAngle;
    Quaternion leftAngle;
    Quaternion centerAngle;

    //need for task
    private GameObject task;
    private int hour = 0; 
    private int minute = 50;
    private string taskname = "Intercom";
    private string tasktitle = "Intercom";

    //task check variables
    public bool TimesUp = false;
    public bool isDone = false;
    public bool QuestActive = false;
    private int num;

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
        num = Random.Range(0,2);
        title.text = InterLines.taskWho[num];
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().TaskQueue("Taskinnit",InterLines.textName[num],InterLines.textInit[num]);
        QuestActive = true;
        task = GameObject.Find("Task Manager").GetComponent<TaskManager>().CreateTaskOnList(taskname,tasktitle,InterLines.textDescription[num]);
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
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().TaskQueue("TaskComplete","Intercom Task Complete",InterLines.textWon[num]);
        DestroyTask();
    }

    private void TaskFailed(){
        Panel.SetActive(false);
        DisablePlayer();
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().TaskQueue("TaskFaile","Intercom Task Failed",InterLines.textLost[num]);
        StaticClass.Grade--;
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
        indicator_ison = false;
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
        if(QuestActive && Panel.activeSelf == true) indicator.SetActive(false);

    }
}