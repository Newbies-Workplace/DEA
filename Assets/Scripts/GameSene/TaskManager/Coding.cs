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

    //need for task
    private GameObject task;
    private int hour = 2; 
    private int minute = 30;
    private string taskname = "Coding";
    private string tasktitle = "Coding";
    private string taskdescription = "Go to ur Desk and do MAGIC bruh!";

    //task check variables
    public static bool TimesUp = false;
    public static bool isDone = false;
    private bool QuestActive;


    private void InnitTask(){
        QuestActive = true;
        task = GameObject.Find("Task Manager").GetComponent<TaskManager>().CreateTaskOnList(taskname,tasktitle,taskdescription);
        TaskTimer.hour = hour;
        TaskTimer.minute = minute;
        TaskTimer.isRunning = true;
    }

    private void CheckTaskStatus(){
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
        DisablePlayer();
        if(isNear(4, player, heart)) if (Input.GetKeyDown(KeyCode.E)) if(WorkPanel != null) WorkPanel.SetActive(true);
    }

    private void DisablePlayer(){
        bool isActive = WorkPanel.activeSelf;
        ThirdPersonController.can_move = !isActive;
        ThirdPersonController.can_move_camera = !isActive;
    }

    private bool isNear(int max_dist, GameObject target, GameObject heart){
        float distance = Vector3.Distance(heart.transform.position, target.transform.position);
        if (distance > max_dist) return false;
        return true;
    }

    void Start(){
        InnitTask();
    }

    void Update()
    {
        AccessComputer();
        CheckTaskStatus();
        
    }
}