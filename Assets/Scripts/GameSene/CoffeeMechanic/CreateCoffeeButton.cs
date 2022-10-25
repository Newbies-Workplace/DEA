using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoffeeButton : MonoBehaviour
{
    [SerializeField] private GameObject type;
    [SerializeField] private GameObject milk;
    [SerializeField] private GameObject sugar;
    [SerializeField] private GameObject requirements;
    [SerializeField] private GameObject panel;

    private int req_type;
    private bool req_milk;
    private int req_sugar;


    void getRequired(){
        req_type = type.GetComponent<ChoiceHandler>().ChoiceValue;
        req_milk = milk.GetComponent<MilkHandler>().isMilk;
        req_sugar = sugar.GetComponent<SugarBar>().current;
    }

    public void CreateCoffee(){
        getRequired();
        if(req_type == requirements.GetComponent<TaskRequire>().Type && req_milk == requirements.GetComponent<TaskRequire>().Milk && req_sugar == requirements.GetComponent<TaskRequire>().Sugar){
            panel.SetActive(false);
            Coffee.isDone = true;
        }
        
    }
}
