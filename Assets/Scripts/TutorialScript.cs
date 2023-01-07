using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private GameObject before;
    [SerializeField] private GameObject actual;
    [SerializeField] private GameObject after;

    public void Next(){
        actual.SetActive(false);
        after.SetActive(true);
    }

    public void Before(){
        actual.SetActive(false);
        before.SetActive(true);
    }

}
