using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystemTouchScreen
{
    public class TouchScreenGameplayInput
    {
        //public event Action<Vector2> OnMouseDelta;
        //public event Action<Vector2> OnMove;

        //public TouchScreenGameplayInput(InputMap _inputMap)
        //{
        //    _inputMap.TouchScreen.TouchDelta.performed += context =>
        //    {
        //        var MouseDelta = context.ReadValue<Vector2>();
        //        OnMouseDelta?.Invoke(MouseDelta);
        //    };
        //    _inputMap.Player.Move.performed += context => InvokeOnMove(context);
        //}
        //public void InvokeOnMove(InputAction.CallbackContext context)
        //{
        //    OnMove?.Invoke(context.ReadValue<Vector2>());
        //}
    }
}
