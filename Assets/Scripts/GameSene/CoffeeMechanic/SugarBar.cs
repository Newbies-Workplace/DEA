using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class SugarBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image mask;

    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill(){
        float fillAmount = (float) current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
