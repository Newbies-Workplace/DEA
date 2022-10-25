using UnityEngine;

public class MondayState : BaseState
{
    public override void EnterState(StateManager state){
        Debug.Log("Its Monday my dudes!");
    }

    public override void UpdateState(StateManager state){
        if(InGameTime.hour == 10 && InGameTime.minute == 0){
            state.SwitchState(state.Tuesday);
        }
    }


}
