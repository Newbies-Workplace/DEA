using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TeleportHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Cinemachine;
    [SerializeField] private GameObject parter;
    [SerializeField] private GameObject pietro;
    [SerializeField] public static bool isWhere = false; //true == parter , false == pietro

    void Start(){
        player = GameObject.Find("Third Person Player");
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            if(isWhere){

                player.GetComponent<Transform>().position = parter.transform.position;
                Cinemachine.GetComponent<CinemachineFreeLook>().ForceCameraPosition(player.transform.position, Quaternion.Euler(150, 0, 0));  
                isWhere = !isWhere;
            }
            else{

                player.GetComponent<Transform>().position = pietro.transform.position;
                Cinemachine.GetComponent<CinemachineFreeLook>().ForceCameraPosition(player.transform.position, Quaternion.Euler(0, 0, 0));
                isWhere = !isWhere;
            }
        }
    }
}
