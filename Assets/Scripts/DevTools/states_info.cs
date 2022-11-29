using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class states_info : MonoBehaviour
{
    [SerializeField] private TMP_Text textfield;
    void Update()
    {
        textfield.text = "| "+GameManager.Instance.State+" | "+PlayerStateManager.Instance.State+" |";
    }
}
