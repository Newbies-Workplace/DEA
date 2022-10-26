using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class IntercomTask : MonoBehaviour
{
    //-------------------------------
    // main variables
    //-------------------------------
    public bool MadeChoice;
    public bool Choice;
    public bool isTaskActive;
    [SerializeField] private GameObject intercom_task;

    //-------------------------------
    // buttons and buttons and texts
    //-------------------------------
    [SerializeField] private Button LetButton;
    [SerializeField] private Button DontLetButton;
    [SerializeField] private TMP_Text DisplayText;
    //[SerializeField] private TMP_Text ---------;


    //-------------------------------------
    // quest information and choices
    //-------------------------------------
    private bool ChoiceGoal = true;
    private string Description = "Hej slodziaku tu Inpost";


    void Start(){
        MadeChoice = false;
        isTaskActive = false;
    }

    private void CheckChoice(){
        if (MadeChoice && !intercom_task.GetComponent<Intercom>().isDone) {
            LetButton.interactable = !MadeChoice;
            DontLetButton.interactable = !MadeChoice;
            
            intercom_task.GetComponent<Intercom>().isDone = true;

            if (Choice == ChoiceGoal){
                Debug.Log("+Repuration");
            }
            else{
                Debug.Log("-Repuration");
            }
            //manage points and reputtation someday
        }
    }

    private void CheckStatus(){
        isTaskActive = intercom_task.GetComponent<Intercom>().QuestActive;
    }

    private void SetUpPanel(){
        if(isTaskActive){
            DisplayText.text = Description;
        }
    }

    void Update(){
        CheckStatus();
        SetUpPanel();
        CheckChoice();
    }

}
