using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public BaseState currentState;
    public MondayState Monday = new MondayState();
    public TuesdayState Tuesday = new TuesdayState();
    public WednesdayState Wednesday = new WednesdayState();
    public ThursdayState Thursday = new ThursdayState();
    public FridayState Friday = new FridayState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = Monday;

        currentState.EnterState(this);
    }
 
    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseState state){
        currentState = state;
        state.EnterState(this);
    }

}
