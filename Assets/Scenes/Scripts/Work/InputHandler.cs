using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Text.RegularExpressions;



public class InputHandler : MonoBehaviour
{
    private string Password = "SayMyName";
    public GameObject IdeWindowInside;
    public GameObject ThisWindow;
    [SerializeField] private TMP_InputField PasswordInput; 
    [SerializeField] private TMP_InputField LoginInput; 

    public void Login(){

        if(PasswordInput.text == Password && LoginInput.text != ""){

            PasswordInput.text = "";
            LoginInput.text = "";
            ThisWindow.SetActive(false);
            IdeWindowInside.SetActive(true);
        }else{
            PasswordInput.text = "";
            LoginInput.text = "";
        }

    }

}
