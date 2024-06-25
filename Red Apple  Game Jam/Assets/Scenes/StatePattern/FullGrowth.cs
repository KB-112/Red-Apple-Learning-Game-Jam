
using UnityEngine;
public class FullGrowth : StateBase
{
    public override void StartState(StateManager state)
    {
       // Debug.Log("Growwing :)");
    
    }
    public override void UpdateState(StateManager state)
    {
        
        state.SwitchState(state.whole); }
    public override void OnCollisionEnter(StateManager state)
    { }


}
