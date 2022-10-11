using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domofon : MonoBehaviour
{
    public bool isOpened = false;  
    public void Start()
    {
        
    }


    public void Answear(){

        if(Input.GetKeyDown(KeyCode.E))
        {
            isOpened = true;
        }
        else
        {
            isOpened = false;
        }

        if(isOpened == true)
            {
                //punkty reputacji +
            }
        else
            {
            //punkty reputacji -
            }
        }
    }

