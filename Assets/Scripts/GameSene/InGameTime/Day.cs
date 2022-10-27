using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day : MonoBehaviour
{
    [SerializeField] private TMP_Text day;

    void Update(){
        if(StaticClass.Weekday == 1) day.text = "Monday";
        if(StaticClass.Weekday == 2) day.text = "Tuesday";
        if(StaticClass.Weekday == 3) day.text = "Wednesday";
        if(StaticClass.Weekday == 4) day.text = "Thursday";
        if(StaticClass.Weekday == 5) day.text = "Friday";
    }
}
