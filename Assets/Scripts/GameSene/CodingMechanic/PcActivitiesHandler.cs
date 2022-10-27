using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PcActivitiesHandler : MonoBehaviour
{
    public bool IsTextInClipboard = false;
    public bool IsWorkDone = false;
    [SerializeField] private TMP_Text CodeTextToCopy;
    [SerializeField] private Button CopyCode_Button;
    [SerializeField] private GameObject qte_copy;
    [SerializeField] private GameObject qte_paste;
    [SerializeField] private Button Paste_Button;
    [SerializeField] private Button exit_button;
    [SerializeField] private TMP_Text CodeTextToPaste;
    
    public bool isBlocked = false;

    void Update()
    {
        IsWorkDoneHandler();
        Qte_handlers();
        if(!IsWorkDone){
            CodeHandler();
        }

        
    }


    void Qte_handlers(){
        bool isActive_copy = qte_copy.activeSelf;
        bool isActive_paste = qte_paste.activeSelf;

    

        if(isActive_copy || isActive_paste){
            exit_button.interactable = false;
            isBlocked = true;
            UiDrag.canDrag = false;
        }else{
            isBlocked = false;
            UiDrag.canDrag = true;
            exit_button.interactable = true;
        }
    }

    void IsWorkDoneHandler(){
        if(IsWorkDone){
            CopyCode_Button.interactable = false;
            Paste_Button.interactable = false;
            CodeTextToCopy.text = "Copied";
            CodeTextToPaste.text = "Pasted";
        }
    }

    void CodeHandler(){
        if(IsTextInClipboard){
            CodeTextToCopy.text = "Copied";
            CopyCode_Button.interactable = false;
            Paste_Button.interactable = true;
        } else {
            CodeTextToCopy.text = "Copy Code";
            CopyCode_Button.interactable = true;
            Paste_Button.interactable = false;
        }
    }
}
