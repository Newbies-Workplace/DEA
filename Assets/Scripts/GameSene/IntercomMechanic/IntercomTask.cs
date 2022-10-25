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
    public static bool MadeChoice;
    public static bool Choice;
    public static bool isTaskActive;

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
        if (MadeChoice && !Intercom.isDone) {
            LetButton.interactable = !MadeChoice;
            DontLetButton.interactable = !MadeChoice;
            
            Intercom.isDone = true;

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
        isTaskActive = Intercom.QuestActive;
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
