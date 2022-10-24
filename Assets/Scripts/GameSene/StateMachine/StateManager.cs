using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    BaseState currentState;
    MondayState Monday = new MondayState();
    TuesdayState Tuesday = new TuesdayState();
    WednesdayState Wednesday = new WednesdayState();
    ThursdayState Thursday = new ThursdayState();
    FridayState Friday = new FridayState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = Monday;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
