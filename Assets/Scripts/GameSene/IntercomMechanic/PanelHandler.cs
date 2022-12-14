using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHandler : MonoBehaviour
{
    [SerializeField] private GameObject Panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            PlayerStateManager.Instance.UpdateState(PlayerState.FreeLook);
            Panel.SetActive(false);
        }
    }
}
