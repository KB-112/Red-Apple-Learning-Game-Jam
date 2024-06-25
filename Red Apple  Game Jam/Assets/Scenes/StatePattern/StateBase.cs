
public abstract class StateBase
{
    public abstract void StartState(StateManager state);
    public abstract void UpdateState(StateManager state);
    public abstract void OnCollisionEnter(StateManager state);
   
}
