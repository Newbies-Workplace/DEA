using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject script;
    public void MilkButton(){
        if(script.GetComponent<MilkHandler>().isMilk == true){
            script.GetComponent<MilkHandler>().isMilk = false;
        }else{
            script.GetComponent<MilkHandler>().isMilk = true;
        }
    }
}
