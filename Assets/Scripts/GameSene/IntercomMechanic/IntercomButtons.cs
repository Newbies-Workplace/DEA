using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntercomButtons : MonoBehaviour
{
    public void LetIn(){ // true == let
        IntercomTask.Choice = true;
        IntercomTask.MadeChoice = true;
    }

    public void DontLetIn(){ // false == dont
        IntercomTask.Choice = false;
        IntercomTask.MadeChoice = true;
    }
}
