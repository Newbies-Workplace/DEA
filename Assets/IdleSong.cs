using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSong : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip music;
    void Start()
    {
        audioSource.PlayOneShot(music);
    }

}
