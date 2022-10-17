using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;

    public GameState State;
    
    public static event Action<GameState> OnGameStateChanged;

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
                Debug.Log("WorkTime");
                break;
            case GameState.EndOfDay:
                Debug.Log("EndOfDay");
                break;
            case GameState.DaySummary:
                Debug.Log("DaySummary");
                break;
            case GameState.WeekEnd:
                Debug.Log("WeekEnd");
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState{
    WorkTime,
    EndOfDay,
    DaySummary,
    WeekEnd,
}