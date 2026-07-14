public class StateMachine
{
    public BaseState CurrentState { get; private set; }

    public void Initialize(BaseState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(BaseState newState)
    {
        if (CurrentState != null)
        {
            CurrentState.Exit(); 
        }

        CurrentState = newState;
        CurrentState.Enter(); 
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}