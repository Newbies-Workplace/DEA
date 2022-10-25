using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkHandler : MonoBehaviour
{
    public bool isMilk = false;
    [SerializeField] private Button Milk;

    
    void Update(){
        if(isMilk){
             Milk.GetComponent<Image>().color = new Color32(139, 204 , 239, 255);
        }
        if(!isMilk){
             Milk.GetComponent<Image>().color = new Color32(255, 255 , 255, 255);
        }
    }
}
