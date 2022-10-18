using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkHandler : MonoBehaviour
{
    public GameObject player; // needed for Distance Check
    public GameObject heart; // needed for Distance Check
    public GameObject WorkPanel;
    public static bool isWorkDone = false;

    bool isNear(int max_dist, GameObject target, GameObject heart){
        float distance = Vector3.Distance(heart.transform.position, target.transform.position);
        if (distance > max_dist) return false;
        return true;
    }

    void Update()
    {
        bool isActive = WorkPanel.activeSelf;
        ThirdPersonController.can_move = !isActive;
        ThirdPersonController.can_move_camera = !isActive;

        if(isNear(4, player, heart)){
            if (Input.GetKeyDown(KeyCode.E)){
                if(WorkPanel != null){
                    WorkPanel.SetActive(true);
                }

            }
        }

        if(isWorkDone){
            PcActivitiesHandler.IsWorkDone = true;
        }else{
            PcActivitiesHandler.IsWorkDone = false;
        }


    }




}
