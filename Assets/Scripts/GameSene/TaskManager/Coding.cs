using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coding : MonoBehaviour
{
    //Need for pc 
    public GameObject player;
    public GameObject heart; 
    public GameObject WorkPanel;
    public GameObject TodoPanel; 
    [SerializeField] private CanvasGroup canvGroup;
    [SerializeField] private GameObject pc_activities_handler;
    [SerializeField] private GameObject indicator;
    [SerializeField] private bool indicator_ison = false;

    //need for task
    private GameObject task;
    private TaskTimer tasktimer;
    private ThirdPersonController Player;
    private SmsManager sms;
    private int hour = 5; 
    private int minute = 30;
    private string taskname = "Coding";
    private string tasktitle = "Coding Task";
    private string taskdescription = "Go to your desk and start coding!";

    //task check variables
    public bool TimesUp = false;
    public bool isDone = false;
    public bool QuestActive;
    private int num;

    void Start(){
        Player = GameObject.Find("Player").GetComponent<ThirdPersonController>();
        sms = GameObject.Find("Sms Manager").GetComponent<SmsManager>();
    }

    public void InnitTask(){
        num = Random.Range(0,3);
        sms.TaskQueue("Taskinnit",CodingLines.textName[num],CodingLines.textInit[num]);
        QuestActive = true;
        isDone = false;
        task = GameObject.Find("Task Manager").GetComponent<TaskManager>().CreateTaskOnList(taskname,tasktitle,taskdescription);
        if(task != null){
            tasktimer = task.transform.Find("title").Find("Time").GetComponent<TaskTimer>();
            tasktimer.hour = hour;
            tasktimer.minute = minute;
            tasktimer.isRunning = true;
        }

    }

    private void DisablePlayer(){
        PlayerStateManager.Instance.UpdateState(PlayerState.UI);
    }

    private void CheckTaskStatus(){
        if(tasktimer.TimesUp && QuestActive) TaskFailed();
        if(isDone && QuestActive) TaskComplete();
    }

    private void TaskComplete(){
        ExitTask();
        sms.TaskQueue("TaskComplete","Coding Task Complete",CodingLines.textWon[num]);
        pc_activities_handler.GetComponent<PcActivitiesHandler>().IsWorkDone = true;
        DestroyTask();
    } 

    private void TaskFailed(){
        ExitTask();
        sms.TaskQueue("TaskFailed","Coding Task Failed",CodingLines.textLost[num]);
        pc_activities_handler.GetComponent<PcActivitiesHandler>().IsWorkDone = true;
        StaticClass.Grade--;
        DestroyTask();   
    }

    private void ExitTask(){
        if(WorkPanel.activeSelf) WorkPanel.SetActive(false);
        WeekStateManager.Instance.CodingDone();
        PlayerStateManager.Instance.UpdateState(PlayerState.FreeLook);
    }

    private void DestroyTask(){
        Destroy(task);
        QuestActive = false;
    }

    private void AccessComputer(){
        if(isNear(4, player, heart)){
            indicator_ison = true;
            if (Input.GetKeyDown(KeyCode.E)) if(WorkPanel != null) {
                WorkPanel.SetActive(true);
                DisablePlayer();
            }
        }
    }

    private bool isNear(int max_dist, GameObject target, GameObject heart){
        float distance = Vector3.Distance(heart.transform.position, target.transform.position);
        if (distance > max_dist) return false;
        return true;
    }

    private void PanelCheckout(){
        bool isActive = WorkPanel.activeSelf;
        if(isActive) canvGroup.alpha = 0;
        if(!isActive) canvGroup.alpha = 1;
    }

    void Update()
    {
        indicator_ison = false;
        PanelCheckout();
        if(QuestActive){
            CheckTaskStatus();
            AccessComputer();
        }
        if(QuestActive) indicator.SetActive(indicator_ison);
        if(!QuestActive) indicator.SetActive(false);
        if(QuestActive && WorkPanel.activeSelf == true) indicator.SetActive(false);
        
    }
}