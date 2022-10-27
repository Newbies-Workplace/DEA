using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntercomButtons : MonoBehaviour
{
    [SerializeField] private GameObject intercomtask;

    public void LetIn(){ // true == let
        intercomtask.GetComponent<IntercomTask>().Choice = true;
        intercomtask.GetComponent<IntercomTask>().MadeChoice = true;
    }

    public void DontLetIn(){ // false == dont
        intercomtask.GetComponent<IntercomTask>().Choice = false;
        intercomtask.GetComponent<IntercomTask>().MadeChoice = true;
    }
}
