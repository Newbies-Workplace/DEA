using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PcActivitiesHandler : MonoBehaviour
{
    public static bool IsTextInClipboard = false;
    public static bool IsWorkDone = false;
    [SerializeField] private TMP_Text CodeTextToCopy;
    [SerializeField] private Button CopyCode_Button;
    [SerializeField] private GameObject qte_copy;
    [SerializeField] private GameObject qte_paste;
    [SerializeField] private Button Paste_Button;
    [SerializeField] private TMP_Text CodeTextToPaste;

    void Update()
    {
        IsWorkDoneHandler();
        if(!IsWorkDone){
            CodeHandler();
            Qte_handlers();
        }

        
    }


    void Qte_handlers(){
        bool isActive_copy = qte_copy.activeSelf;
        bool isActive_paste = qte_paste.activeSelf;

        if(isActive_copy || isActive_paste){
            PanelManager.isBlocked = true;
            UiDrag.canDrag = false;
        }else{
            PanelManager.isBlocked = false;
            UiDrag.canDrag = true;
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
