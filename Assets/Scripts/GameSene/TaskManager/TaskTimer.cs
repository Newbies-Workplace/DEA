using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskTimer : MonoBehaviour{
    
    public float hour;
    public float minute;
    public bool isRunning;
    private float timeRemaining = 0;
    public bool TimesUp = false;
    [SerializeField] private TMP_Text TimerText;       

    void Start(){
        ChangeTime();
    }

    void Update(){
        if(isRunning){
            if(timeRemaining > 0 ){
                timeRemaining -= Time.deltaTime * 120;
                DisplayTime(timeRemaining);
            }else if (timeRemaining < 0){
                TimesUp = true;
            }

        }
    }

    void ChangeTime(){
        minute = minute+hour*60;
        hour = 0;
        timeRemaining = minute*60;
        minute = 0;
    }

    void DisplayTime(float timeToDisplay){
        float hour = Mathf.FloorToInt(timeToDisplay / 60 / 60); 
        float minute = Mathf.FloorToInt((timeToDisplay / 60) % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", hour, minute);
    }
}
