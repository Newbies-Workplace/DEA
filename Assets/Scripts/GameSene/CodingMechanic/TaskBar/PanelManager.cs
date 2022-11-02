using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
	public GameObject Panel;
    [SerializeField] private GameObject pc_activities_handler;
	
    public void HidePanel()
    {
        if (!pc_activities_handler.GetComponent<PcActivitiesHandler>().isBlocked) Panel.SetActive(false);
	}

    public void ShowPanel()
    {
        if (!pc_activities_handler.GetComponent<PcActivitiesHandler>().isBlocked) Panel.SetActive(true);
	}

    public void TogglePanel()
    {
        if (!pc_activities_handler.GetComponent<PcActivitiesHandler>().isBlocked){
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }

	}

    public void ExitComputer(){
        if (!pc_activities_handler.GetComponent<PcActivitiesHandler>().isBlocked) Panel.SetActive(false);
        GameObject.Find("Player").GetComponent<ThirdPersonController>().can_move = true;
        GameObject.Find("Player").GetComponent<ThirdPersonController>().can_move_camera = true;
        ThirdPersonController.isVisibleCursor = false;
    }

    public void ToggleApplication()
    {
        if (!pc_activities_handler.GetComponent<PcActivitiesHandler>().isBlocked){
            bool isActive = Panel.activeSelf;
            RectTransform rectTransform = Panel.GetComponent<RectTransform>();
            Panel.SetActive(!isActive);
            rectTransform.SetAsLastSibling();
        }

	}


}
