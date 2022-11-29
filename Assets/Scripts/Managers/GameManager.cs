using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                ResetTime();

                break;
            case GameState.EndOfDay:

                break;
            case GameState.DaySummary:
                ChangeToDaySummary();

                break;
            case GameState.WeekEnd:
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
        InGameTime.hour = 8;
        InGameTime.minute = 0;
    }
}

public enum GameState{
    WorkTime,
    EndOfDay,
    DaySummary,
    WeekEnd,
}