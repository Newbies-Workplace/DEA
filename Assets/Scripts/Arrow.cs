using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform target;
    [SerializeField] public GameObject IndicatorHandler;
    [SerializeField] public GameObject Arrow1;
    [SerializeField] public GameObject StairsUp;
    [SerializeField] public GameObject StairsDown;
    [SerializeField] public List<GameObject> Up;
    [SerializeField] public List<GameObject> Down;

    [SerializeField] private GameObject task_object_coding; //up
    [SerializeField] private GameObject task_object_thermostat; // up
    [SerializeField] private GameObject task_object_coffee; // down
    [SerializeField] private GameObject task_object_intercom; //up

    [SerializeField] private  bool ActualFloor; //true == parter , false == pietro
    [SerializeField] private  bool checkup; //true == parter , false == pietro
    [SerializeField] private  bool checkdown; //true == parter , false == pietro

    
    void Start(){


    }

    void Update()
    {
        ActualFloor = TeleportHandler.isWhere;
        target = IndicatorHandler.GetComponent<IndicatorHandler>().CurrentTask.transform;
        if(target.name == "No Task"){
            Arrow1.GetComponent<MeshRenderer>().enabled = false;
        }else{
            Arrow1.GetComponent<MeshRenderer>().enabled = true;
        }
        Transform holder = target;
        if(CheckFloor(target.name) == ActualFloor){
            if(ActualFloor == true) target = StairsUp.transform;
            if(ActualFloor == false) target = StairsDown.transform;
        }else{
            target = holder;
        }

        Vector3 targetPosition = target.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
    }

    private bool CheckFloor(string name){
        bool floor = false;    //true == parter , false == pietro
        switch(name) 
        {
        case "Coding":
            floor = false;
            break;
        case "Coffee":
            floor = true;
            break;
        case "Intercom":
            floor = false;
            break;
        case "Thermostat":
            floor = false;
            break;
        }

        return floor;
    }   
}
