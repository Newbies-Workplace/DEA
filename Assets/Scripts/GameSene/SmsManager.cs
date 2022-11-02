using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SmsManager : MonoBehaviour
{
    [SerializeField]private GameObject TaskList;
    [SerializeField] private CanvasGroup canvGroup;
    [SerializeField]private GameObject PropTask;

    private bool mFaded = false;
    float smoothFactor = 1.0f;
    private float Duration = 0.3f;
    [SerializeField] GameObject destination;
    [SerializeField] GameObject deafult;
    
    public void CreateSMS(string taskname, string tasktitle, string taskdescription){
        
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
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0, task,TaskList,deafult));
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end, GameObject task, GameObject panel, GameObject destination){
        yield return new WaitForSecondsRealtime(4);
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
        
    }

    public IEnumerator DoSlide(GameObject panel){
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            panel.GetComponent<RectTransform>().position = Vector3.Lerp(panel.GetComponent<RectTransform>().position, destination.transform.position, Time.deltaTime * smoothFactor);
            
            yield return null; 
        }
    }

}