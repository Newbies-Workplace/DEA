using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameTime : MonoBehaviour
{
    
    public static int day = 0; // start as monday
    public static int hour = 8; // starts as 8:xx
    public static int minute = 0; // starts as x:00
    public static bool time_stop = true;
    float seccond;

    string[] weekday_list = {"monday", "tuesday", "wednesday", "thursday", "friday"};

    void Update(){  
        if(!time_stop){

            seccond += Time.deltaTime * 120;
            

            if (seccond >= 60){
                seccond = 0;
                minute++;
            }

            if (minute == 60){
                minute = 0;
                hour++;
            }

            //in case || no need at all
            if (hour == 24) hour = 0;

        }
    }
}
