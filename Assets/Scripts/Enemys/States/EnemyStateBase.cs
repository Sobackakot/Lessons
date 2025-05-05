using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.EnemyState
{
    
    public abstract class EnemyStateBase : IStateGame
    {
        public EnemyStateBase(IBexaviourHandler bexaviourHandler)
        {                       
            this.bexaviourHandler = bexaviourHandler;
        }
        public  abstract EnemyStateType stateType { get; set; }
        public readonly IBexaviourHandler bexaviourHandler;
        

          public abstract void EnterState();
          public abstract void ExitState();
          public abstract void UpdateState();
          public abstract void FixedUpdateState();
          public abstract void LateUpdateState();
    }
    public enum EnemyStateType
    {
        Idel,
        Follow,
        Move
    }
}
