using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskRequire : MonoBehaviour
{

    public int Sugar;
    public int Type;
    public bool Milk;

    void Update(){
        Sugar = CoffeeLines.taskSugar[Coffee.num];
        Type = CoffeeLines.taskType[Coffee.num];
        Milk = CoffeeLines.taskMilk[Coffee.num];
        //more later 
        //changed when calling task from statemachine
    } 
}
