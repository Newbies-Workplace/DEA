using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;

    public GameState State;
    
    public static event Action<GameState> OnGameStateChanged;
    public 

    void Awake(){
        Instance = this;
    }
    
    void Start(){
        UpdateGameState(GameState.WorkTime);
    }

    public void UpdateGameState(GameState newState){
        State = newState;

        switch (newState) {
            case GameState.WorkTime:
                ResetTime();
                Debug.Log("WorkTime");
                break;
            case GameState.EndOfDay:
                Debug.Log("EndOfDay");
                break;
            case GameState.DaySummary:
                ChangeToDaySummary();
                Debug.Log("DaySummary");
                break;
            case GameState.WeekEnd:
                Debug.Log("WeekEnd");
                ChangeToEnd();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void ChangeToDaySummary(){
        SceneManager.LoadScene("DaySummary");
    }

    private void ChangeToEnd(){
        SceneManager.LoadScene("EndOfWeek");
    }

    private void ResetTime(){
        InGameTime.hour = TimeManager.day_start_hour;
        InGameTime.minute = 0;
    }
}

public enum GameState{
    WorkTime,
    EndOfDay,
    DaySummary,
    WeekEnd,
}