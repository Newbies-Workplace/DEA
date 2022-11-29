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
    [SerializeField] private GameObject Panel;
    [SerializeField] private Button Paste_Button;
    [SerializeField] private TMP_Text CodeTextToPaste;
    private bool CanExit = true;
    public bool isBlocked = false;

    void Update()
    {
        IsWorkDoneHandler();
        Qte_handlers();
        ExitPC();
        if(!IsWorkDone) CodeHandler();
        
    }

    void ExitPC(){
        if(CanExit && Input.GetKeyDown(KeyCode.Escape)){
            Panel.SetActive(false);
            PlayerStateManager.Instance.UpdateState(PlayerState.FreeLook);
        }
    }

    void Qte_handlers(){
        if(qte_copy.activeSelf || qte_paste.activeSelf){
            isBlocked = true;
            UiDrag.canDrag = false;
            CanExit = false;
        }

        if(!qte_copy.activeSelf || !qte_paste.activeSelf){
            isBlocked = false;
            UiDrag.canDrag = true;
            CanExit = true;
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
        }
        if(!IsTextInClipboard){
            CodeTextToCopy.text = "Copy Code";
            CopyCode_Button.interactable = true;
            Paste_Button.interactable = false;
        }
    }
}
