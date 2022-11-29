using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioSource mySounds;

    public void ClickSound(){
        mySounds.PlayOneShot(clickSound);
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ButtonSounds : MonoBehaviour
// {
//     public AudioSource mySounds;
//     public AudioClip hoverSound;
//     public AudioClip clickSound;

//     public void HoverSound(){
//         mySounds.PlayOneShot(hoverSound);
//     }
//     public void ClickSound(){
//         mySounds.PlayOneShot(clickSound);
//     }
// }
