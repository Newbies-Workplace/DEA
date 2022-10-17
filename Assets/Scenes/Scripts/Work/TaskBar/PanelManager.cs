using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
	public GameObject Panel;
    public static bool isBlocked = false;
	
    public void HidePanel()
    {
        if (!isBlocked) Panel.SetActive(false);
	}

    public void ShowPanel()
    {
        if (!isBlocked) Panel.SetActive(true);
	}

    public void TogglePanel()
    {
        if (!isBlocked){
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }

	}

    public void ToggleApplication()
    {
        if (!isBlocked){
            bool isActive = Panel.activeSelf;
            RectTransform rectTransform = Panel.GetComponent<RectTransform>();
            Panel.SetActive(!isActive);
            rectTransform.SetAsLastSibling();
        }

	}


}
