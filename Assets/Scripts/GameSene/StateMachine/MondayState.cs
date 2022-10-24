using UnityEngine;

public class MondayState : BaseState
{
    public override void EnterState(StateManager state){
        Debug.Log("Its Monday my dudes!");
    }

    public override void UpdateState(StateManager state){
        
    }
}
