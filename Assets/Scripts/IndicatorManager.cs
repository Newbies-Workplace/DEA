using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{
    [SerializeField] private GameObject task_coding;
    [SerializeField] private GameObject task_thermostat;
    [SerializeField] private GameObject task_coffee;
    [SerializeField] private GameObject task_intercom;
    [SerializeField] private GameObject task_printer;
    [SerializeField] private GameObject NoneTask; 

    [SerializeField] private GameObject task_object_coding;
    [SerializeField] private GameObject task_object_thermostat;
    [SerializeField] private GameObject task_object_coffee;
    [SerializeField] private GameObject task_object_intercom;
    [SerializeField] private GameObject task_object_printer;

    [SerializeField] private bool task_activ_coding;   
    [SerializeField] private bool task_activ_thermostat;   
    [SerializeField] private bool task_activ_coffee;   
    [SerializeField] private bool task_activ_intercom;   
    [SerializeField] private bool task_activ_printer;   
    
    [SerializeField] private bool task_in_list_coding = false;
    [SerializeField] private bool task_in_list_thermostat = false;
    [SerializeField] private bool task_in_list_coffee = false;
    [SerializeField] private bool task_in_list_intercom = false;
    [SerializeField] private bool task_in_list_printer = false;

    [SerializeField] public List<GameObject> list;
    [SerializeField] public int TaskCount;


    void Start()
    {
        list = new List<GameObject>();
        list.Add(NoneTask);
    }

    // Update is called once per frame
    void Update()
    {
        task_activ_coding = task_coding.GetComponent<Coding>().QuestActive;
        task_activ_thermostat = task_thermostat.GetComponent<Thermostat>().QuestActive;
        task_activ_coffee = task_coffee.GetComponent<Coffee>().QuestActive;
        task_activ_intercom = task_intercom.GetComponent<Intercom>().QuestActive;
        task_activ_printer = task_printer.GetComponent<Printer>().QuestActive;
        
        if(task_in_list_coding == false && task_activ_coding == true){
            list.Add(task_object_coding);
            task_in_list_coding = true;
        }
        if(task_in_list_thermostat == false && task_activ_thermostat == true){
            list.Add(task_object_thermostat);
            task_in_list_thermostat = true;
        }
        if(task_in_list_coffee == false && task_activ_coffee == true){
            list.Add(task_object_coffee);
            task_in_list_coffee = true;
        }
        if(task_in_list_intercom == false && task_activ_intercom == true){
            list.Add(task_object_intercom);
            task_in_list_intercom = true;
        }
        if(task_in_list_printer == false && task_activ_printer == true){
            list.Add(task_object_printer);
            task_in_list_printer = true;
        }

        if(task_in_list_coding == true && task_activ_coding == false){
            list.Remove(task_object_coding);
            task_in_list_coding = false;
        }

        if(task_in_list_coffee == true && task_activ_coffee == false){
            list.Remove(task_object_coffee);
            task_in_list_coffee = false;
        }

        if(task_in_list_thermostat == true && task_activ_thermostat == false){
            list.Remove(task_object_thermostat);
            task_in_list_thermostat = false;
        }

        if(task_in_list_intercom == true && task_activ_intercom == false){
            list.Remove(task_object_intercom);
            task_in_list_intercom = false;
        }

        if(task_in_list_printer == true && task_activ_printer == false){
            list.Remove(task_object_printer);
            task_in_list_printer = false;
        }

        TaskCount = list.Count;

    }
}
