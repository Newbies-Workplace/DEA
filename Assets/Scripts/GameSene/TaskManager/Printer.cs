using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject heart;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject indicator;
    [SerializeField] private bool indicator_ison = false;

    public float range = 3;
    int max_dist = 3;

    Quaternion rightAngle;
    Quaternion leftAngle;
    Quaternion centerAngle;

    private GameObject task;
    private SmsManager sms;
    private TaskTimer tasktimer;
    private int hour = 1; 
    private int minute = 30;
    private string taskname = "Printer";
    private string tasktitle = "Printer";

    public bool TimesUp = false;
    public bool isDone = false;
    public bool QuestActive = false;
    private int num;

    void Start()
    {
        leftAngle = Quaternion.Euler(10,-30,0);
        rightAngle = Quaternion.Euler(10,30,0);
        centerAngle = Quaternion.Euler(10,0,0);
        sms = GameObject.Find("Sms Manager").GetComponent<SmsManager>();
    }

    private bool isNear(int max_dist, GameObject target, GameObject heart){
        float distance = Vector3.Distance(heart.transform.position, target.transform.position);
        if (distance > max_dist) return false;
        return true;
    }

    public void InnitTask(){
        num = Random.Range(0,3);
        sms.TaskQueue("Taskinnit",PrinterLines.textName[num],PrinterLines.textInit[num]);
        QuestActive = true;
        isDone = false;
        task = GameObject.Find("Task Manager").GetComponent<TaskManager>().CreateTaskOnList(taskname,tasktitle,PrinterLines.textDescription[num]);
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
        sms.TaskQueue("TaskComplete","Printer Task Complete",PrinterLines.textWon[num]);
        DestroyTask();
    }

    private void TaskFailed(){
        sms.TaskQueue("TaskFailed","Printer Task Failed",PrinterLines.textLost[num]);
        StaticClass.Grade--;
        DestroyTask();   
    }

    private void DestroyTask(){
        WeekStateManager.Instance.PrinterDone();
        Destroy(task);
        QuestActive = false;
    }

    private void AccessObject(){
        //if(isNear(2, player, heart)) if (Input.GetKeyDown(KeyCode.E))
        if(isNear(4,player,heart)){
            if( Input.GetKeyDown(KeyCode.E)){
                animator.SetTrigger("Printer");
                StartCoroutine(EndTask());
            }
        }
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
        if(QuestActive) indicator.SetActive(indicator_ison);
        if(!QuestActive) indicator.SetActive(false);


    }


    public IEnumerator EndTask(){
        yield return new WaitForSecondsRealtime(2);
        isDone = true;
        
    }

}
