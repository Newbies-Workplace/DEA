// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class CodeStatusHandler : MonoBehaviour
// {
//     public static bool visible = true;
//     public TMP_Text code_text;
//     public static int code_value = 0;
//     int code_max_value_today;
//     int[] code_max_values = {100,150,200,250,300};
//     void Start()
//     {
//       code_max_value_today = code_max_values[InGameTimer.day]; 
//       code_text.text = "kod: " +code_value + " /" +code_max_value_today;
//     }

//     void Update()
//     {
//       if(visible) code_text.text = "kod: " +code_value + " /" +code_max_value_today;
//       if(!visible) code_text.text = "";
//     }
// }
