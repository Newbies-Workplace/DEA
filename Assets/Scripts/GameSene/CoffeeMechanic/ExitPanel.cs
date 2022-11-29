using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel : MonoBehaviour
{
    [SerializeField] private GameObject Panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Panel.SetActive(false);
            PlayerStateManager.Instance.UpdateState(PlayerState.FreeLook);
        }
    }
}

