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

    //need for task
    private GameObject task;
    private int hour = 0; 
    private int minute = 5;
    private string taskname = "Coding";
    private string tasktitle = "Coding Task";
    private string taskdescription = "Go to the computer in your room and write a feature";

    //task check variables
    public bool TimesUp = false;
    public bool isDone = false;
    private bool QuestActive;


    public void InnitTask(){
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().CreateSMS("Taskinnit","Oskar [DEA]","Remember about feature which you told you're gonna finish this week.");
        QuestActive = true;
        task = GameObject.Find("Task Manager").GetComponent<TaskManager>().CreateTaskOnList(taskname,tasktitle,taskdescription);
        if(task != null){
            task.transform.Find("title").Find("Timer").GetComponent<TaskTimer>().hour = hour;
            task.transform.Find("title").Find("Timer").GetComponent<TaskTimer>().minute = minute;
            task.transform.Find("title").Find("Timer").GetComponent<TaskTimer>().isRunning = true;
        }

    }

    private void CheckTaskStatus(){
        TimesUp = task.transform.Find("title").Find("Timer").GetComponent<TaskTimer>().TimesUp;
        if(TimesUp && QuestActive) TaskFailed();
        if(isDone && QuestActive) TaskComplete();
    }

    private void TaskComplete(){
        WorkPanel.SetActive(false);
        GameObject.Find("Player").transform.Find("ThirdPersonPlayer").GetComponent<ThirdPersonController>().can_move = true;
        GameObject.Find("Player").transform.Find("ThirdPersonPlayer").GetComponent<ThirdPersonController>().can_move_camera = true;
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().CreateSMS("TaskComplete","Coding Task Complete","We are happy about your contribution into your tasks. We'll have a talk later ;)");
        pc_activities_handler.GetComponent<PcActivitiesHandler>().IsWorkDone = true;
        DestroyTask();
    } 

    private void TaskFailed(){
        WorkPanel.SetActive(false);
        GameObject.Find("Player").transform.Find("ThirdPersonPlayer").GetComponent<ThirdPersonController>().can_move = true;
        GameObject.Find("Player").transform.Find("ThirdPersonPlayer").GetComponent<ThirdPersonController>().can_move_camera = true;
        GameObject.Find("Sms Manager").GetComponent<SmsManager>().CreateSMS("TaskFailed","Coding Task Failed","We are concerned about your contribution into your tasks. We'll have a talk later...");
        pc_activities_handler.GetComponent<PcActivitiesHandler>().IsWorkDone = true;
        DestroyTask();   
    }

    private void DestroyTask(){
        Destroy(task);
        QuestActive = false;
    }

    private void AccessComputer(){
        if(isNear(4, player, heart)) if (Input.GetKeyDown(KeyCode.E)) if(WorkPanel != null) {
            WorkPanel.SetActive(true);
            GameObject.Find("Player").transform.Find("ThirdPersonPlayer").GetComponent<ThirdPersonController>().can_move = false;
            GameObject.Find("Player").transform.Find("ThirdPersonPlayer").GetComponent<ThirdPersonController>().can_move_camera = false;
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
        PanelCheckout();
        if(QuestActive){
            CheckTaskStatus();
            AccessComputer();
        }
        
    }
}