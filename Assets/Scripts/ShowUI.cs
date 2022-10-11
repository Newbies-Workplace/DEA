using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;
    void Update()
    {
        uiObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider playerObject)
    {
        if(playerObject.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine(WaitForSec());
        }
        IEnumerator WaitForSec()
        {
            yield return new WaitForSeconds(3);
            Destroy(uiObject);
            Destroy(gameObject);
        }
    }
}
