public interface IStateMachine
{
    void ChangeState(State toState);
    void ChangeState(string toState);
    void AddState(State state);
    void RemState(State state);
    void UpdateActiveState();
    void FixedUpdateActiveState();
}
