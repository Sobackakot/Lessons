using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;


public class InputSystemTest : MonoBehaviour
{
    public event Action<Vector2> OnMove;
    private InputAction _inputActionUnity;
    private PlayerInput _playerInputUnityComponent;
    private InputMap _input;
    private void Awake()
    {
        _input = new();
        _playerInputUnityComponent = GetComponent<PlayerInput>();
        SetInputAction();
    }
   
    private void Update()
    {
        OnMove?.Invoke(_inputActionUnity.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Move.performed += context => InvokeOnMove(context);
        _input.Player.Move.canceled += context => InvokeOnMove(context);
    }
    private void OnDisable()
    {
        _input.Player.Move.performed -= context => InvokeOnMove(context);
        _input.Player.Move.canceled -= context => InvokeOnMove(context);
        _input.Dispose();
    }

    public void InvokeOnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnMove?.Invoke(_inputActionUnity.ReadValue<Vector2>());
            Debug.Log(_inputActionUnity.ReadValue<Vector2>());
        }
        else if (context.canceled)
        {
            OnMove?.Invoke(Vector2.zero);
        }
    }
    private void SetInputAction() 
    {
        _inputActionUnity = _playerInputUnityComponent.actions["Move"];
    }
}
    