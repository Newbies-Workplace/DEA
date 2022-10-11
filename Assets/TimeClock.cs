using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System;

public class TimeClock : MonoBehaviour
{
    public Text timer;
    public Text weekday;
    public static int day = 0;
    public static float hour = 8;
    public float minute = 0;
    float seccond = 0;
    string[] weekday_list = {"monday", "tuesday", "wednesday", "thursday", "friday"};

    void Start()
    {
        weekday.text = weekday_list[day].ToString();
    }


    void Update(){
        seccond += Time.deltaTime * 30;
        
        Debug.Log(seccond);

        if (seccond >= 60){
            seccond = 0;
            minute++;
        }

        if (minute == 60){
            minute = 0;
            hour++;
        }

        if (hour == 24){
            hour = 0;
        }

        timer.text = hour + ":" + minute.ToString("00");
    }
}