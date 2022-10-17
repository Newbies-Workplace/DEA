using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class QuickTimeEvent : MonoBehaviour
{   
    public int KeyToPress = 0; // 0 = c , 1 = p;
    public int maximum;
    public int current;
    public Image mask;
    [SerializeField] private GameObject QtePanel;
    [SerializeField] private TMP_Text percentage_text;

    void Update()
    {
        if (KeyToPress == 0){
            if (Input.GetKeyDown(KeyCode.C)) current++;
        }else if (KeyToPress == 1){
            if (Input.GetKeyDown(KeyCode.P)) current++;
        }
        GetCurrentFill();
        FillPercent();

        if(current == maximum) {
            current = 0;
            QtePanel.SetActive(false);
            PanelManager.isBlocked  = false;
            if(PcActivitiesHandler.IsTextInClipboard){
                PcActivitiesHandler.IsTextInClipboard = false;
                WorkHandler.isWorkDone = true;
            }else{
                PcActivitiesHandler.IsTextInClipboard = true;
            }
            
        }
    }

    void FillPercent(){
        float percentage = ((current * maximum) /100);
        percentage_text.text = percentage + "%";
    }

    void GetCurrentFill(){
        float fillAmount = (float) current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
