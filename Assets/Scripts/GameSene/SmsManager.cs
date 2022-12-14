using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SmsManager : MonoBehaviour
{
    [SerializeField]private GameObject TaskList;
    [SerializeField]private CanvasGroup canvGroup;
    [SerializeField]private GameObject PropTask;
    [SerializeField]private AudioSource sms_audio;
    [SerializeField]private AudioClip sound;

    private bool mFaded = false;
    float smoothFactor = 1.0f;
    private float Duration = 0.3f;
    [SerializeField] GameObject destination;
    [SerializeField] GameObject deafult;

    //TaskQueue 
    private bool WorkInProgress = false;
    private List<string> TaskName = new List<string>();
    private List<string> TaskTitle = new List<string>();
    private List<string> TaskDescription = new List<string>();

    
    private void CreateSMS(string taskname, string tasktitle, string taskdescription){
        WorkInProgress = true;


        //in case of warious things like my Alzheimer
        canvGroup.alpha = 1;
        PropTask.SetActive(false);


        //Clone gameObject from PropTask and change name 
        GameObject task = Instantiate(PropTask);
        task.name = taskname;

        //Set title and description
        GameObject TaskTitle = task.transform.Find("title").gameObject.transform.Find("Name").gameObject;
        TaskTitle.GetComponent<TMP_Text>().text = tasktitle;
        GameObject TaskDescription = task.transform.Find("TaskDescription").gameObject;
        TaskDescription.GetComponent<TMP_Text>().text = taskdescription;

        //set Parent to TaskList
        task.transform.SetParent(TaskList.transform, false);

        TaskList.SetActive(true);
        task.SetActive(true);

        StartCoroutine(DoSlide(TaskList));
        sms_audio.PlayOneShot(sound);
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0, task,TaskList,deafult));
    }

    //Add task to queque
    public void TaskQueue(string taskname, string tasktitle, string taskdescription){
        TaskName.Add(taskname);
        TaskTitle.Add(tasktitle);
        TaskDescription.Add(taskdescription);
    }
    
    //if can, then do task from queque
    void Update(){
        if(!WorkInProgress && TaskName.Count != 0 && TaskTitle.Count != 0 && TaskDescription.Count != 0){
            CreateSMS(TaskName[0],TaskTitle[0],TaskDescription[0]);
            TaskName.Remove(TaskName[0]);
            TaskTitle.Remove(TaskTitle[0]);
            TaskDescription.Remove(TaskDescription[0]);
        }
    }


    private IEnumerator DoFade(CanvasGroup canvGroup, float start, float end, GameObject task, GameObject panel, GameObject destination){
        yield return new WaitForSecondsRealtime(5);
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);
            
            yield return null; 
        }
        TaskList.SetActive(false);
        Destroy(task);
        panel.GetComponent<RectTransform>().position = destination.transform.position;
        WorkInProgress = false;
        
    }

    private IEnumerator DoSlide(GameObject panel){
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            if(panel.GetComponent<RectTransform>().position != destination.transform.position){
                panel.GetComponent<RectTransform>().position = Vector3.Lerp(panel.GetComponent<RectTransform>().position, destination.GetComponent<RectTransform>().position, Time.deltaTime * smoothFactor);
            }
            
            yield return null; 
        }
    }

}