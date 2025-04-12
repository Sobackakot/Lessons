using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystemTouchScreen;
using System;

public class RotateCamera : MonoBehaviour
{
    private GamePlayInputManager _input;
    private Transform _myTr;
    private float sensitiviti = 20f;
    private float horisontal = 0;
    private float vertical = 0;
    private void OnEnable()
    {
        _input = FindObjectOfType<GamePlayInputManager>();
        _input.OnMouseDelta += CameraRotateMethod;
        _myTr = transform;
    }

    private void CameraRotateMethod(Vector2 delta)
    {
        var dt = Time.deltaTime;
        vertical -= sensitiviti * delta.x * dt;
        horisontal += sensitiviti * delta.y * dt;
        _myTr.eulerAngles = new Vector3(horisontal, vertical, 0);

    }

    private void OnDisable()
    {
        _input.OnMouseDelta -= CameraRotateMethod;
    }

}
