using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_unhide_tools : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private bool isActive;

    void Start(){
        isActive = false;
    }
    void Update()
    {
        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.F8)){
            Panel.SetActive(!isActive);
            isActive = !isActive;
        }
    }
}
