using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkEndHandler : MonoBehaviour
{
    void Update()
    {
        int time = (int) TimeClock.hour;
        if (time >=9){
            SceneManager.LoadScene("day_summary");
        }
    }
}
