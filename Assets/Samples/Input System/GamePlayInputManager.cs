using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace InputSystemTouchScreen
{
    public class GamePlayInputManager : MonoBehaviour
    {
        private InputMap _inputMap;
        private TouchScreenGameplayInput _touchScreenInput;
        public Vector3 Axis {get; private set;}
        public event Action<Vector2> OnMouseDelta;

        private void OnEnable()
        {
            _inputMap = new();
            _inputMap.Enable();
            InitTouchScreenInput();
        }
        private void InitTouchScreenInput()
        {
            //_touchScreenInput = new(_inputMap);
            //_touchScreenInput.OnMouseDelta += MoveMouseDelta;
            //_touchScreenInput.OnMove += MoveInput;
        }
        private void OnDisable()
        {
            //_touchScreenInput.OnMouseDelta -= MoveMouseDelta;
            //_touchScreenInput.OnMove -= MoveInput;
        }
        private void MoveMouseDelta(Vector2 delta)
        {
            OnMouseDelta?.Invoke(delta);
        }
        public void MoveInput(Vector2 axis)
        {
            Axis = new Vector3(axis.x, 0, axis.y);
        }
    }
    
}

