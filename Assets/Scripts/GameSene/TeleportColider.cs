using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportColider : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        Debug.Log("colided1");
        if(col.gameObject.tag == "Player"){
            Debug.Log("colided");
        }
    }
}
 