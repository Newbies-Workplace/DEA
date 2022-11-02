using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [SerializeField]private GameObject PropTask;
    [SerializeField]private GameObject TaskList;

    public GameObject CreateTaskOnList(string taskname, string tasktitle, string taskdescription){
        
        //in case of warious things like my Alzheimer
        PropTask.SetActive(false);

        //Clone gameObject from PropTask and change name 
        GameObject task = Instantiate(PropTask);
        task.name = taskname;

        //Set title and description
        GameObject TaskTitle = task.transform.Find("title").gameObject.transform.Find("Name").gameObject;
        TaskTitle.GetComponent<TMP_Text>().text = tasktitle;
        GameObject TaskDescription = task.transform.Find("TaskDescription").gameObject;
        TaskDescription.GetComponent<TMP_Text>().text = taskdescription;

        //set time to none
        GameObject TaskTime = task.transform.Find("title").gameObject.transform.Find("Timer").gameObject.transform.Find("Time").gameObject;       
        TaskTime.GetComponent<TMP_Text>().text = "";


        //set Parent to TaskList
        task.transform.SetParent(TaskList.transform, false);
        task.SetActive(true);

        return(task);
    }
}
