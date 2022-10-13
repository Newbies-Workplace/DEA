using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
	public GameObject Panel;
	
    public void HidePanel()
    {
        Panel.SetActive(false);
	}

    public void ShowPanel()
    {
        Panel.SetActive(true);
	}

    public void TogglePanel()
    {
        bool isActive = Panel.activeSelf;
        Panel.SetActive(!isActive);
	}


}
