using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndicatorHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text tasktext;
    [SerializeField] private GameObject Coding;
    [SerializeField] private GameObject Coffee;
    [SerializeField] private GameObject Intercom;
    [SerializeField] private GameObject Thermostat;

    [SerializeField] private GameObject ListScript; 
    [SerializeField] public GameObject CurrentTask = null; 
    [SerializeField] public int TaskCount; 
    [SerializeField] public int CurrentCount = 0; 

    void Update()
    {
        TaskCount = ListScript.GetComponent<IndicatorManager>().TaskCount;
        if(CurrentCount > TaskCount) CurrentCount = 0;

        if(!Coding.activeSelf && !Coffee.activeSelf && !Intercom.activeSelf && !Thermostat.activeSelf){
            if (Input.GetKeyDown(KeyCode.Comma)){ // -
                if(CurrentCount > 0 ){
                    CurrentCount--;
                }
            }
            if (Input.GetKeyDown(KeyCode.Period)){ // +
                if(CurrentCount < TaskCount-1 ){
                    CurrentCount++;
                }
            }
    
            try{
                CurrentTask = ListScript.GetComponent<IndicatorManager>().list[CurrentCount];
            }catch{
                CurrentTask = ListScript.GetComponent<IndicatorManager>().list[0];
            }
            tasktext.text = CurrentTask.name;
        }
    }
}
