using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskBarClock : MonoBehaviour
{

    public TMP_Text timer;
    public TMP_Text day;

    void Update()
    {
        string time = InGameTimer.hour.ToString() + ":" + InGameTimer.minute.ToString("00");
        timer.text = InGameTimer.hour.ToString() + ":" + InGameTimer.minute.ToString("00");
    }
}
