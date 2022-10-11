using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneHandler : MonoBehaviour
{

    public void NextScene()
    {
        TimeClock.hour = 8;
        TimeClock.day++;
        SceneManager.LoadScene("monday");
    }
}
