using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystemTouchScreen;

public class Player : MonoBehaviour
{
    public float MHp = 6;
    public float Hp;
    public Transform CameraTr;
    private Vector3 _newAxis;
    private Vector3 _newLookAxis;
    private GamePlayInputManager _input;
    [SerializeField]
    private Rigidbody _myRb;


    private void Awake()
    {
        _input = FindObjectOfType<GamePlayInputManager>();
    }
    private void Start()
    {
        Hp = MHp;
       // Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Move(_newAxis);
        LookMove(_newLookAxis);
        if (Hp <= MHp)
            Hp = Hp + 0.03f * Time.deltaTime;
    }
    private void OnEnable()
    {
        _input.OnMouseDelta += InputGetLookAxis;
    }
    private void OnDisable()
    {
        _input.OnMouseDelta -= InputGetLookAxis;
    }
    public void InputGetAxis(Vector2 axis)
    {
         _newAxis = new Vector3(axis.x,0,axis.y);
    }
    public void InputGetLookAxis(Vector2 axis)
    {
        _newLookAxis = new Vector3(axis.x, 0, axis.y);
    }
    public void Move(Vector3 axis)
    {
        _myRb.MovePosition(transform.position + axis * 15 * Time.deltaTime);
    }
    public void LookMove(Vector3 axis)
    {
      
    }

}


