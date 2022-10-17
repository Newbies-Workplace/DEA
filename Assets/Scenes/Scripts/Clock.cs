using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField] private TMP_Text Time;
    
    void Update()
    {
        Time.text = InGameTime.hour + ":" + InGameTime.minute.ToString("00");
        
    }
}
