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
    [SerializeField] private GameObject coding;
    [SerializeField] private GameObject intercom;
    [SerializeField] private GameObject coffee;
    [SerializeField] private GameObject thermostatic;
    [SerializeField] private GameObject printer;
    [SerializeField] private GameObject heater;

    //ONLY NEED IN UPDATE METHOD FOR KNOWNING IS ACTIVATED
    private bool codingTask_task = false;
    private bool intercom_task = false;
    private bool coffee_task = false;
    private bool thermostatic_task = false;
    private bool printer_task = false;
    private bool heater_task = false;

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
                // MondayHandler();
                break;
                
            case State.Tuesday:
                Debug.Log("Tuesday");
                // TuesdayHandler();
                break;

            case State.Wednesday:
                Debug.Log("Wednesday");
                // WednesdayHandler();
                break;
                
            case State.Thursday:
                Debug.Log("Thursday");
                // ThursdayHandler();
                break;
        
            case State.Friday:
                Debug.Log("Friday");
                // FridayHandler();
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

    //caling those are here:
    // coding.GetComponent<Coding>().InnitTask();
    // coffee.GetComponent<Coffee>().InnitTask();
    // thermostatic.GetComponent<thermostatic>().InnitTask();
    // intercom.GetComponent<Intercom>().InnitTask();

    //----------------------------------------------------------------
    //MONDAY
    //----------------------------------------------------------------
    private void MondayUpdate(){
        if(InGameTime.hour == 8 && InGameTime.minute == 5 && !codingTask_task) {
            coding.GetComponent<Coding>().InnitTask();
            codingTask_task = true;
        }

        if(InGameTime.hour == 8 && InGameTime.minute == 10 && !printer_task) {
            printer.GetComponent<Printer>().InnitTask();
            printer_task = true;
        }

        // if(InGameTime.hour == 8 && InGameTime.minute == 10 && !heater_task) {
        //     heater.GetComponent<Heater>().InnitTask();
        //     heater_task = true;
        // }

        if(InGameTime.hour == 8 && InGameTime.minute == 15 && !coffee_task) {
            coffee.GetComponent<Coffee>().InnitTask();
            coffee_task = true;
        }
    }


    //----------------------------------------------------------------  
    //THUESDAY
    //----------------------------------------------------------------
    private void TuesdayUpdate(){
        if(InGameTime.hour == 8 && InGameTime.minute == 5 && !thermostatic_task) {
            thermostatic.GetComponent<Thermostat>().InnitTask();
            thermostatic_task = true;
        }

        if(InGameTime.hour == 8 && InGameTime.minute == 15 && !coffee_task) {
            coffee.GetComponent<Coffee>().InnitTask();
            coffee_task = true;
        }
    }


    //----------------------------------------------------------------
    //WEDNESDAY
    //----------------------------------------------------------------
    private void WednesdayUpdate(){
        if(InGameTime.hour == 8 && InGameTime.minute == 5 && !intercom_task) {
            intercom.GetComponent<Intercom>().InnitTask();
            intercom_task = true;
        }        
        
        if(InGameTime.hour == 8 && InGameTime.minute == 15 && !coffee_task) {
            coffee.GetComponent<Coffee>().InnitTask();
            coffee_task = true;
        }
    }


    //----------------------------------------------------------------
    //THURSDAY
    //----------------------------------------------------------------
    private void ThursdayUpdate(){
        if(InGameTime.hour == 8 && InGameTime.minute == 5 && !codingTask_task) {
            coding.GetComponent<Coding>().InnitTask();
            codingTask_task = true;
        }

        if(InGameTime.hour == 8 && InGameTime.minute == 15 && !coffee_task) {
            coffee.GetComponent<Coffee>().InnitTask();
            coffee_task = true;
        }
    }


    //----------------------------------------------------------------
    //FRIDAY
    //----------------------------------------------------------------
    private void FridayUpdate(){
        if(InGameTime.hour == 8 && InGameTime.minute == 5 && !codingTask_task) {
            coding.GetComponent<Coding>().InnitTask();
            codingTask_task = true;
        }

        if(InGameTime.hour == 8 && InGameTime.minute == 15 && !coffee_task) {
            coffee.GetComponent<Coffee>().InnitTask();
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