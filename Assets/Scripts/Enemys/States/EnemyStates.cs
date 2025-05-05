using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State.EnemyState;
public class EnemyStates
{
}
public class EnemyIdleState : EnemyStateBase
{

    public EnemyIdleState(IBexaviourHandler bexaviourHandler) : base(bexaviourHandler)
    {
        stateType = EnemyStateType.Idel;
    }
    public override EnemyStateType stateType { get; set; }


    public override void EnterState()
    {

        bexaviourHandler?.EneterBexaviour();// везде добавил опператор <?> для обработки исключеней 
    }

    public override void ExitState()
    {
        bexaviourHandler?.ExidBexaviour();
    }

    public override void UpdateState()
    {
        bexaviourHandler?.Update();
    }
    public override void LateUpdateState()
    {
        bexaviourHandler?.LateUpdate(); 
    }

    public override void FixedUpdateState()
    {
        bexaviourHandler?.FixedUpdate();

    }
}
    public class EnemyMoveState : EnemyStateBase
    {
        public EnemyMoveState(IBexaviourHandler bexaviourHandler) : base(bexaviourHandler)
        {
           stateType = EnemyStateType.Move;
        }
         public override EnemyStateType stateType { get; set; }
        public override void EnterState()
        {
            bexaviourHandler?.EneterBexaviour();// везде добавил опператор <?> для обработки исключеней 
        }

        public override void ExitState()
        {
            bexaviourHandler?.ExidBexaviour();
        }

        public override void UpdateState()
        {
            bexaviourHandler?.Update();
        }
        public override void LateUpdateState()
        {
            bexaviourHandler?.LateUpdate();
        }

        public override void FixedUpdateState()
        {
            bexaviourHandler?.FixedUpdate();

        }
    }
public class EnemyFollowStates : EnemyStateBase
{
    public EnemyFollowStates(IBexaviourHandler bexaviourHandler) : base(bexaviourHandler)
    {
        stateType = EnemyStateType.Follow;
    }
    public override EnemyStateType stateType { get; set; }

    public override void EnterState()
    {
        bexaviourHandler?.EneterBexaviour();// везде добавил опператор <?> для обработки исключеней 
    }

    public override void ExitState()
    {
        bexaviourHandler?.ExidBexaviour();
    }

    public override void UpdateState()
    {
        bexaviourHandler?.Update();
    }
    public override void LateUpdateState()
    {
        bexaviourHandler?.LateUpdate();
    }

    public override void FixedUpdateState()
    {
        bexaviourHandler?.FixedUpdate();
    }

}
