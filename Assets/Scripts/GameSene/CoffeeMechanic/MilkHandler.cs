using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkHandler : MonoBehaviour
{
    public bool isMilk = false;
    public Color newColor;
    ColorBlock _normal;
    ColorBlock _pressed;
    [SerializeField] private Button Milk;

    // void Start(){
    //     ColorBlock _normal = ColorBlock.defaultColorBlock;
    //     _normal.normalColor = new Color32(255, 255 , 255, 255);
    //     ColorBlock _pressed = ColorBlock.defaultColorBlock;
    //     _pressed.normalColor = new Color32(204, 20 , 16, 255);
    // }

    void Update(){
        if(!isMilk){
            ColorBlock cb = Milk.colors;
            cb.normalColor = new Color32(255, 255 , 255, 255);
            cb.highlightedColor = new Color32(255, 255 , 255, 255);
            cb.pressedColor = new Color32(255, 255 , 255, 255);
            cb.selectedColor = new Color32(255, 255 , 255, 255);
            Milk.colors = cb;
        }
        if(isMilk){
            ColorBlock cb = Milk.colors;
            cb.normalColor = new Color32(63, 190 , 253, 100);
            cb.highlightedColor = new Color32(63, 190 , 253, 100);
            cb.pressedColor = new Color32(63, 190 , 253, 100);
            cb.selectedColor = new Color32(63, 190 , 253, 100);
            Milk.colors = cb;
        }
    }
}
