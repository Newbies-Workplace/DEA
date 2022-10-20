using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StackAskQuestion : MonoBehaviour
{
    [SerializeField] private TMP_InputField SearchField; 
    public GameObject IdeWindowInside;
    public GameObject ThisWindow;
    
    public void AskQuestion(){ 
        if(SearchField.text != ""){
            ThisWindow.SetActive(false);
            SearchField.text = "";;
            RectTransform rectTransform = IdeWindowInside.GetComponent<RectTransform>();
            IdeWindowInside.SetActive(true);
            rectTransform.SetAsLastSibling();
            
        }
    }
}
