using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace State
{
    public interface IStateGame
    {
         void EnterState();
         void ExitState();
         void UpdateState();
         void FixedUpdateState();
         void LateUpdateState();

    }
}
