using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State;


public class EnemyStateHandler : IStateHandler
{
    private IStateGame _currentState;
    public void SetState(IStateGame newState)
    {
        if (newState != _currentState && newState != null) 
        {
            _currentState?.ExitState();// везде добавил опператор <?> для обработки исключеней 
            _currentState = newState;
            _currentState?.EnterState();
        }
        
    }

    public void UpdateState()
    {
        _currentState?.UpdateState();
    }
    public void LateUpdateState()
    {
        _currentState?.LateUpdateState();
    }
    public void FixedUpdateState()
    {
        _currentState?.FixedUpdateState();
    }
}
public interface IStateHandler
{
    public void SetState(IStateGame newState);
    public void UpdateState();
}


