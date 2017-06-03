using System.Collections.Generic;

public abstract class StateMachine : IStateMachine
{
    private Dictionary<string, State> states = new Dictionary<string, State>();
    private State currentState = null;


    #region Constructors
    public StateMachine()
    {
        currentState = null;
    }
    #endregion

    #region Class Method
    public void AddState(State state)
    {
        if(state != null)
        {
            if(!states.ContainsKey(state.Name))
                states.Add(state.Name, state);
        }
    }

    public void ChangeState(string toState)
    {
        if (states.ContainsKey(toState))
        {
            if (currentState != null)
                currentState.OnExit();
            currentState = states[toState];
            currentState.OnEnter();
        }
    }

    public void ChangeState(State toState)
    {
        if (toState != null)
        {
            if(currentState != null)
                currentState.OnExit();
            currentState = toState;
            currentState.OnEnter();
        }
    }

    public void FixedUpdateActiveState()
    {
        if (currentState != null)
            currentState.OnFixedUpdate();
    }

    //Removes state from list
    public void RemState(State state)
    {
        states.Remove(state.Name);
    }

    public void UpdateActiveState()
    {
        if (currentState != null)
            currentState.OnUpdate();
    }
    #endregion
}
