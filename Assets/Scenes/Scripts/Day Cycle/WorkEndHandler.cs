using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkEndHandler : MonoBehaviour
{
    void Update()
    {
        int time = (int) InGameTimer.hour;
        if (time >=9){
            SceneManager.LoadScene("DaySummary");
        }
    }
}
