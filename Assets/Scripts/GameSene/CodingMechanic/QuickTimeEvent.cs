using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class QuickTimeEvent : MonoBehaviour
{   
    public int KeyToPress = 0; // 0 = c , 1 = p;
    public int maximum;
    public int current;
    public Image mask;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;
    [SerializeField] private GameObject QtePanel;
    [SerializeField] private TMP_Text percentage_text;
    [SerializeField] private GameObject coding;
    [SerializeField] private GameObject pc_activities_handler;
    [SerializeField] private IdleSong idlesong;

    void Update()
    {
        if (KeyToPress == 0){
            if (Input.GetKeyDown(KeyCode.C)){
                current++;
                source.PlayOneShot(clip);
            }
        }else if (KeyToPress == 1){
            if (Input.GetKeyDown(KeyCode.P)){
                current++;
                source.PlayOneShot(clip);
            }
        }
        GetCurrentFill();
        FillPercent();

        if(current == maximum) {
            current = 0;
            QtePanel.SetActive(false);
            idlesong.Resume();
            pc_activities_handler.GetComponent<PcActivitiesHandler>().isBlocked = false;
            if(pc_activities_handler.GetComponent<PcActivitiesHandler>().IsTextInClipboard){
                pc_activities_handler.GetComponent<PcActivitiesHandler>().IsTextInClipboard = false;
                coding.GetComponent<Coding>().isDone = true;
            }else{
                pc_activities_handler.GetComponent<PcActivitiesHandler>().IsTextInClipboard = true;
            }
            
        }
    }

    void FillPercent(){
        float percentage = ((current * 100) /maximum);
        percentage_text.text = percentage + "%";
    }

    void GetCurrentFill(){
        float fillAmount = (float) current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
