using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetDayName : MonoBehaviour
{
    [SerializeField] private TMP_Text title;

    void Start()
    {
        int value = StaticClass.Weekday;
        if (value == 1) title.text = "End of the Monday";
        if (value == 2) title.text = "End of the Tuesday";
        if (value == 3) title.text = "End of the Wednesday";
        if (value == 4) title.text = "End of the Thursday";
        if (value == 5) title.text = "End of the Friday"; 
    }
}

