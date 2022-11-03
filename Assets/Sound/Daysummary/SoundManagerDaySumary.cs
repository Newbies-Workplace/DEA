using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerDaySumary : MonoBehaviour
{
    [SerializeField] private AudioSource audiosSource;
    void Start()
    {
        audiosSource.Play();       
    }
}
