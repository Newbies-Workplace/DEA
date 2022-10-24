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

    public void Login(){

        if(PasswordInput.text == Password){

            PasswordInput.text = "";
            ThisWindow.SetActive(false);
            RectTransform rectTransform = IdeWindowInside.GetComponent<RectTransform>();
            IdeWindowInside.SetActive(true);
            rectTransform.SetAsLastSibling();
        }else{
            PasswordInput.text = "";
        }

    }

}
