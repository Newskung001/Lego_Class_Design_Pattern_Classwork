public class BossStateMachine
{
    private IBossState _currentState;

    public IBossState CurrentState => _currentState;

    public void ChangeState(IBossState newState)
    {
        if (_currentState != null) _currentState.Exit();
        _currentState = newState;
        if (_currentState != null) _currentState.Enter();
    }

    public void Tick()
    {
        if (_currentState != null) _currentState.Tick();
    }
}
