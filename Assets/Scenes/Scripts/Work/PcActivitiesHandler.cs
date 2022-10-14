using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PcActivitiesHandler : MonoBehaviour
{
    public static bool IsTextInClipboard = false;
    [SerializeField] private TMP_Text CopyCode_Button_Text;
    [SerializeField] private Button CopyCode_Button;


    void Start()
    {
        
    }

    void Update()
    {
        CopiedHandler();
    }


    void CopiedHandler(){
        if(IsTextInClipboard){
            CopyCode_Button_Text.text = "Copied";
            CopyCode_Button.interactable = false;
        } else {
            CopyCode_Button_Text.text = "Copy Code";
            CopyCode_Button.interactable = true;
        }
    }
}
