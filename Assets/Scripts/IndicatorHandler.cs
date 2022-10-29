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
    [SerializeField] public GameObject CurrentTask; 
    [SerializeField] public int TaskCount; 
    [SerializeField] public int CurrentCount; 


    
    void Start(){
        CurrentCount = 0;
        CurrentTask = null;
    }


    void Update()
    {
        TaskCount = ListScript.GetComponent<IndicatorManager>().TaskCount;
        if(CurrentCount > TaskCount) CurrentCount = 0;

        if(!Coding.activeSelf && !Coffee.activeSelf && !Intercom.activeSelf && !Thermostat.activeSelf){
            if (Input.GetKeyDown(KeyCode.Z)){ // -
                if(CurrentCount > 0 ){
                    CurrentCount--;
                }
            }
            if (Input.GetKeyDown(KeyCode.X)){ // +
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
