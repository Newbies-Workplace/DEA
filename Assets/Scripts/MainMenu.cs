using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Exit(){
        Application.Quit();
    }

    public void StartGame(){
        SceneManager.LoadScene("Game");
    }
}
