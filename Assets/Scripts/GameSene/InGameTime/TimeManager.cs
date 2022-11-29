using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int EndDayValue = 9;
    public static int FinalEndDayValue = 13;
 

    void Update()
    {
        DayCycleHandler();
    }


    void DayCycleHandler( ){
        
        if(InGameTime.hour >= EndDayValue && InGameTime.minute > 0 && GameManager.Instance.State == GameState.WorkTime){
            GameManager.Instance.UpdateGameState(GameState.EndOfDay);
        }

        if(InGameTime.hour >= FinalEndDayValue && InGameTime.minute > 0 && GameManager.Instance.State == GameState.EndOfDay){
            GameManager.Instance.UpdateGameState(GameState.DaySummary);
        }

        if(InGameTime.hour >= FinalEndDayValue && InGameTime.minute > 0 && GameManager.Instance.State == GameState.EndOfDay && StaticClass.Weekday == 5){
            GameManager.Instance.UpdateGameState(GameState.WeekEnd);
        }
    }

}
