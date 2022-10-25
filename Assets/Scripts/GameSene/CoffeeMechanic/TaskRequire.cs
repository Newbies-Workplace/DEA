using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskRequire : MonoBehaviour
{

    public int Sugar;
    public int Type;
    public bool Milk;

    void Start(){
        Sugar = 0;
        Type = 1;
        Milk = false;
        //more later 
        //changed when calling task from statemachine
    } 
}
