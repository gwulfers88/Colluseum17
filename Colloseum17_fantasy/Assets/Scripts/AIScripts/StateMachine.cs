using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class StateMachine : IStateMachine
{
    private Dictionary<string, State> states = new Dictionary<string, State>();
    private State currentState = null;

    #region Class Method
    public void AddState(State state)
    {
        
    }

    public void ChangeState(string toState)
    {
        if (states.ContainsKey(toState))
        {
            currentState = states[toState];
            currentState.OnEnter();
        }
    }

    public void ChangeState(State toState)
    {
        if()
    }

    public void FixedUpdateActiveState()
    {
        if (ActiveState != null)
            ActiveState.FixedUpdate();
    }

    //Removes state from list
    public void RemState(State state)
    {
        State.Remove(state);
    }

    public void UpdateActiveState()
    {
        if (ActiveState != null)
            ActiveState.Update();
    }
    #endregion
}
