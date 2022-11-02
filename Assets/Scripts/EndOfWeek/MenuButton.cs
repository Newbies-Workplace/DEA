using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void GoToMenu(){
        Debug.Log("c");
        SceneManager.LoadScene("MainMenu");
    }
}
