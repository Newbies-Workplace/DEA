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

    //need for task
    private GameObject task;
    private int hour = 0; 
    private int minute = 15;
    private string taskname = "Coding";
    private string tasktitle = "Coding";
    private string taskdescription = "Go to ur Desk and do MAGIC bruh!";

    //task check variables
    public bool TimesUp = false;
    public static bool isDone = false;
    private bool QuestActive;


    private void InnitTask(){
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
        Debug.Log("TaskComplete"); // reputation or something else and aojdasiodsadisa
        PcActivitiesHandler.IsWorkDone = true;
        DestroyTask();
    } 

    private void TaskFailed(){
        Debug.Log("TaskFailed"); // reputation or something else and aojdasiodsadisa
        PcActivitiesHandler.IsWorkDone = true;
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
        TodoPanel.SetActive(!isActive);

    }

    void Start(){
        InnitTask();
    }

    void Update()
    {
        PanelCheckout();
        AccessComputer();
        if(QuestActive) CheckTaskStatus();
        
    }
}