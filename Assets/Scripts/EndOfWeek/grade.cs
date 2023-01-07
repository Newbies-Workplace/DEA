using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class grade : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    void Start()
    {
        if(StaticClass.Grade == 6){
            title.text = "Your grade is: 6";
        }
        if(StaticClass.Grade == 5){
            title.text = "Your grade is: 5";
        }  
        if(StaticClass.Grade == 4){
            title.text = "Your grade is 4";
        }  
        if(StaticClass.Grade == 3){
            title.text = "Your grade is 3";
        }  
        if(StaticClass.Grade == 2){
            title.text = "Your grade is 2";
        }   
        if(StaticClass.Grade <= 1){
            title.text = "Your grade is 1";
        }      
    }

}
