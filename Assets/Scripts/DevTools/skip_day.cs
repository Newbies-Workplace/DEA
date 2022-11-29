using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skip_day : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    void Update()
    {
        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.F7) && Panel.activeSelf)
        {
            if(StaticClass.Weekday == 5) GameManager.Instance.UpdateGameState(GameState.WeekEnd);
            if(StaticClass.Weekday != 5) GameManager.Instance.UpdateGameState(GameState.DaySummary);
        }
    }
}
