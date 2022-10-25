using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeekStateManager : MonoBehaviour{
    public static WeekStateManager Instance;

    //----------------------------------------------------------------
    //game tasks mechanics 
    //----------------------------------------------------------------
    [SerializeField] private GameObject Coding;
    [SerializeField] private GameObject Intercom;
    [SerializeField] private GameObject Coffee;
    [SerializeField] private GameObject Thermostatic;

    private bool codingTask_task;
    private bool intercom_task;
    private bool coffee_task;
    private bool thermostatic_task;

    public State State;
    
    public static event Action<State> OnGameStateChanged;

    void Awake(){
        Instance = this;
    }
    
    void Start(){
        if (StaticClass.Weekday == 0) StaticClass.Weekday = 1;
        
        SetupState();
    }

    void Update(){
        if(State == State.Monday) MondayUpdate();
        if(State == State.Tuesday) TuesdayUpdate();
        if(State == State.Wednesday) WednesdayUpdate();
        if(State == State.Thursday) ThursdayUpdate();
        if(State == State.Friday) FridayUpdate();
    }

    public void UpdateState(State newState){
        State = newState;

        switch (newState) {
            case State.Monday:
                Debug.Log("Monday");
                MondayHandler();
                break;
                
            case State.Tuesday:
                Debug.Log("Tuesday");
                TuesdayHandler();
                break;

            case State.Wednesday:
                Debug.Log("Wednesday");
                WednesdayHandler();
                break;
                
            case State.Thursday:
                Debug.Log("Thursday");
                ThursdayHandler();
                break;
        
            case State.Friday:
                Debug.Log("Friday");
                FridayHandler();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void SetupState(){
        if(StaticClass.Weekday == 1) UpdateState(State.Monday);
        if(StaticClass.Weekday == 2) UpdateState(State.Tuesday);
        if(StaticClass.Weekday == 3) UpdateState(State.Wednesday);
        if(StaticClass.Weekday == 4) UpdateState(State.Thursday);
        if(StaticClass.Weekday == 5) UpdateState(State.Friday);
    }

    private void MondayHandler(){
        Coding.GetComponent<Coding>().InnitTask();
        Intercom.GetComponent<Intercom>().InnitTask();
        Thermostatic.GetComponent<Thermostat>().InnitTask();
    }

    private void MondayUpdate(){
        if(InGameTime.hour == 8 && InGameTime.minute == 30 && !coffee_task) {
            Coffee.GetComponent<Coffee>().InnitTask();
            coffee_task = true;
        }
    }

    private void TuesdayHandler(){
        Coding.GetComponent<Coding>().InnitTask();
    }
    private void TuesdayUpdate(){
        if(InGameTime.hour == 8 && InGameTime.minute == 30 && !coffee_task) {
            Coffee.GetComponent<Coffee>().InnitTask();
            coffee_task = true;
        }
    }

    private void WednesdayHandler(){
        Coding.GetComponent<Coding>().InnitTask();
    }
    private void WednesdayUpdate(){
        if(InGameTime.hour == 8 && InGameTime.minute == 30 && !coffee_task) {
            Coffee.GetComponent<Coffee>().InnitTask();
            coffee_task = true;
        }
    }

    private void ThursdayHandler(){
        Coding.GetComponent<Coding>().InnitTask();
    }
    private void ThursdayUpdate(){
        if(InGameTime.hour == 8 && InGameTime.minute == 30 && !coffee_task) {
            Coffee.GetComponent<Coffee>().InnitTask();
            coffee_task = true;
        }
    }

    private void FridayHandler(){
        Coding.GetComponent<Coding>().InnitTask();
    }
    private void FridayUpdate(){
        if(InGameTime.hour == 8 && InGameTime.minute == 30 && !coffee_task) {
            Coffee.GetComponent<Coffee>().InnitTask();
            coffee_task = true;
        }
    }

}

public enum State{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
}