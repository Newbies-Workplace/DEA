using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    int hour, minute, day; 
    public static int day_start_hour = 8;
    bool checkTime = false;
    public int EndDayValue = 9;
    public int FinalEndDayValue = 10;
    GameState State;
 

    void Awake(){
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    void Destroy(){
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameState state){
        if(state == GameState.WorkTime) checkTime = true;
        State = state;   
    }

    void Update()
    {
        hour = InGameTime.hour;
        minute = InGameTime.minute;
        day = InGameTime.day;
        if(checkTime) DayCycleHandler(State);
    }


    void DayCycleHandler(GameState State){
        
        if(hour == EndDayValue && minute == 0 && State == GameState.WorkTime){
            GameManager.Instance.UpdateGameState(GameState.EndOfDay);
        }

        if(hour == FinalEndDayValue && minute == 0 && State == GameState.EndOfDay){
            GameManager.Instance.UpdateGameState(GameState.DaySummary);
        }
    }

}
