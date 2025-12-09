public class BossStateMachine
{
    public IBossState CurrentState { get; private set; }

    public void Initialize(IBossState initialState)
    {
        CurrentState = initialState;
        CurrentState.Enter();
    }

    public void ChangeState(IBossState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void Tick()
    {
        CurrentState?.Tick();
    }
}
