using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject Script;
    
    public void DepressoButton(){
        Script.GetComponent<ChoiceHandler>().ChoiceValue = 1;
    }

    public void LatteButton(){
        Script.GetComponent<ChoiceHandler>().ChoiceValue = 2;
    }
    
    public void KapuczinaButton(){
        Script.GetComponent<ChoiceHandler>().ChoiceValue = 3;
    }

    public void BlackButton(){
        Script.GetComponent<ChoiceHandler>().ChoiceValue = 4;
        
    }
}
