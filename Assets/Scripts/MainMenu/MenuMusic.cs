using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audiosSource;
    void Start()
    {
        audiosSource.Play();       
    }
}

