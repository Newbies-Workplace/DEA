using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceHandler : MonoBehaviour
{

    public int ChoiceValue = 0; // 0 none, 1 depresso, 2 latte, 3 kapuczina, 4 black
    [SerializeField] private Button Depresso; 
    [SerializeField] private Button Latte; 
    [SerializeField] private Button Kapuczina; 
    [SerializeField] private Button Black; 

    void Update(){
        SelectButton();
    }

    void SelectButton(){
        InteractAll();
        switch (ChoiceValue) 
        {
        case 1:
            Depresso.interactable = false;
            break;
        case 2:
            Latte.interactable = false;
            break;
        case 3:
            Kapuczina.interactable = false;
            break;
        case 4:
            Black.interactable = false;
            break;
            }
    }

    void InteractAll(){
        Depresso.interactable = true;
        Latte.interactable = true;
        Kapuczina.interactable = true;
        Black.interactable = true;
    }
}
