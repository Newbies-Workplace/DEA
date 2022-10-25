using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeDay : MonoBehaviour
{
    public void NextDay(){
        StaticClass.Weekday++;
        SceneManager.LoadScene("Game");
        InGameTime.day++;
    }
}

