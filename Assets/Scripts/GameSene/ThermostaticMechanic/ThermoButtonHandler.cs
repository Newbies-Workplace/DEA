using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermoButtonHandler : MonoBehaviour
{
    
    public void CountUp(){
        ThermoHandler.ThermoStatValue++;
    }

    public void CountDown(){
        ThermoHandler.ThermoStatValue--;
    }
}
