using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class QuickTimeEvent : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image mask;
    [SerializeField] private GameObject QtePanel;
    [SerializeField] private TMP_Text percentage_text;

    void Start(){
        PanelManager.isBlocked = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) current++;
        GetCurrentFill();
        FillPercent();

        if(current == maximum) {
            current = 0;
            QtePanel.SetActive(false);
            PanelManager.isBlocked  = false;
            PcActivitiesHandler.IsTextInClipboard = true;
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
