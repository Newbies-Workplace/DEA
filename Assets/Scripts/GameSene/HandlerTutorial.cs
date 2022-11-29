using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerTutorial : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private AudioSource player;
    [SerializeField] private GameObject todo;
    [SerializeField] private GameObject indi;
    [SerializeField] private bool RunTutorial;
    void Start()
    {
        if (RunTutorial){
            if(StaticClass.Weekday == 1){
                panel.SetActive(true);
                GameObject.Find("Player").GetComponent<ThirdPersonController>().can_move = false;
                GameObject.Find("Player").GetComponent<ThirdPersonController>().can_move_camera = false;
                ThirdPersonController.isVisibleCursor = true;
                player.enabled = false;
                todo.SetActive(false);
                indi.SetActive(false);
            }
        }

    }

}
