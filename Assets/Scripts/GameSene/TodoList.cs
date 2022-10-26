using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodoList : MonoBehaviour
{
    [SerializeField] private GameObject List;

    [SerializeField] private GameObject Coding;
    [SerializeField] private GameObject Coffee;
    [SerializeField] private GameObject Intercom;
    [SerializeField] private GameObject Thermostatic;

    void Update()
    {
        if (!Coding.activeSelf) List.SetActive(true);
        if (!Coffee.activeSelf) List.SetActive(true);
        if (!Intercom.activeSelf) List.SetActive(true);
        if (!Thermostatic.activeSelf) List.SetActive(true);
    }
}
