using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeDay : MonoBehaviour
{
    public void NextDay(){
        //GameManager.Instance.UpdateGameState(GameState.WorkTime); // should be already changed by loading scene 
        SceneManager.LoadScene("Game");
        InGameTime.day++;
    }
}
