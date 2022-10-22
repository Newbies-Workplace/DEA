using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThermoHandler : MonoBehaviour
{
    public static int ThermoStatValue = 25;

    [SerializeField] private GameObject ThermoPanel;
    [SerializeField] private TMP_Text ThermoPanelText;
    void Update()
    {
        ThermoPanelText.text = ThermoStatValue+"*C";
        if (Input.GetKeyDown(KeyCode.Escape)){
            ThermoPanel.SetActive(false);
        }
        if(ThermoStatValue == Thermostat.TaskGoal){
            Thermostat.isDone = true;
        }
    }
}
