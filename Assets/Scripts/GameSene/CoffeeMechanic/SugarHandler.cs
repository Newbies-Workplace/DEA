using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarHandler : MonoBehaviour
{
    [SerializeField] private GameObject SugarBar;

    
    public void AddSugar(){
        if(SugarBar.GetComponent<SugarBar>().current != SugarBar.GetComponent<SugarBar>().maximum){
            SugarBar.GetComponent<SugarBar>().current++;
        }
    }

    public void RemoveSugar(){
        if(SugarBar.GetComponent<SugarBar>().current != 0){
            SugarBar.GetComponent<SugarBar>().current--;
        }
    }
}
