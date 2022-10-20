using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskTimer : MonoBehaviour{
    
    public static float hour;
    public static float minute;
    public static bool isRunning;
    private float timeRemaining = 0;
    [SerializeField] private TMP_Text TimerText;       

    void Update(){
        ChangeTime();
        if(isRunning){
            if(timeRemaining > 0 ){
                timeRemaining -= Time.deltaTime * 30;
                Debug.Log(timeRemaining);
                DisplayTime(timeRemaining);
            }
        }
    }

    void ChangeTime(){
        while(hour !=0 && minute !=0){
            minute += hour*60;
            hour = 0;
            timeRemaining += minute*60;
            minute = 0;
        }
    }

    void DisplayTime(float timeToDisplay){
        float hour = Mathf.FloorToInt(timeToDisplay / 60 / 60); 
        float minute = Mathf.FloorToInt((timeToDisplay / 60) % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", hour, minute);
    }
}
