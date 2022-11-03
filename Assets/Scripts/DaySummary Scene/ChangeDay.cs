using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeDay : MonoBehaviour
{
    public void NextDay(){
        if(StaticClass.Grade <= 1){
            SceneManager.LoadScene("EndOfWeek");
        }else{
            StaticClass.Weekday++;
            SceneManager.LoadScene("Game");
            InGameTime.day++;
        }

    }
}

