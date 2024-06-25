using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    StateBase currentState;
    Eaten eatenState = new Eaten();
   public Whole whole = new Whole();
    Rotten rotten = new Rotten();
    FullGrowth fullGrowth = new FullGrowth();



    private void Start()
    {
        currentState = fullGrowth;
        currentState.StartState(this);
    }
    public void Update()
    {
        currentState.UpdateState(this);
    }
  public  void SwitchState(StateBase state)
    {
        currentState = state;
          state.StartState(this);
    }
}
