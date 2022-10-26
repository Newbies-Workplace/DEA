using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SkipDay : MonoBehaviour
{
    public void skipday(){
        SceneManager.LoadScene("DaySummary");
    }
}
