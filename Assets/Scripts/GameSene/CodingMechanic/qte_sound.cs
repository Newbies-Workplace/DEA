using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qte_sound : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;
    [SerializeField] private IdleSong idlesong;
    
    

    void Start()
    {
        source.PlayOneShot(clip);
        idlesong.Pause();
    }

}
