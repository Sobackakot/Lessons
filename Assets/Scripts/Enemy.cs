using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,
    IEnemyAttack,
    IEnemyFollow,
    IEnemyRandomMove,
    IEnemyRandomRotate,
    IEnemyRotate
{
    private Rigidbody _myRb;
    private Transform _playerTr;
    public Player _player;
    private Transform _enemyTr;
    [SerializeField]
    private float _speedOfRotate = 1;
    [SerializeField]
    private float _speedOfMove = 5;
    [SerializeField]
    private float _minDistanceLookTarget = 25;
    private float _timeOfLastRotation;
    [SerializeField]
    private float _minDistanceFollowTarget = 15;
    private float _timeRotation;
    private bool _isInCollision;
    private Vector3 _dierectionOfRotate=Vector3.zero;

    void Awake()
    {
        _myRb = GetComponent<Rigidbody>();
        _timeRotation = Random.Range(3, 6);
        _enemyTr = GetComponent<Transform>();
        _player = FindObjectOfType<Player>();
        _playerTr = FindObjectOfType<Player>().transform;
    }

    void FixedUpdate()
    {
        RandomRotate();
        LookRotate();
        Moving();
    }
    private void LateUpdate()
    {
        FollowTarget();
    }

    public void LookRotate()
    {
        if(IsMinDistanse(_minDistanceLookTarget))
        {
            Vector3 dierection = _playerTr.position - _enemyTr.position;
            dierection.y = 0;
            Quaternion rotate = Quaternion.LookRotation(dierection);
            Quaternion lerpRotate = Quaternion.Slerp(_enemyTr.rotation, rotate, _speedOfRotate * Time.fixedDeltaTime);
            _myRb.MoveRotation(lerpRotate);
        }
    }
    public void FollowTarget()
    {
        if (IsMinDistanse(_minDistanceFollowTarget))
        {
            _enemyTr.position = Vector3.MoveTowards(_enemyTr.position, _playerTr.position, _speedOfMove * Time.deltaTime);
        }
    }
    public void Moving()
    {
        if (!IsMinDistanse(_minDistanceLookTarget))
        {
            Vector3 MV = new Vector3(0,0,1);
            _enemyTr.localPosition = _enemyTr.position + _dierectionOfRotate* Time.fixedDeltaTime*0.5f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Attack(collision);    
    }

    public void RandomRotate()
    {
        if (!IsMinDistanse(_minDistanceLookTarget))
        {
            if(Time.time - _timeOfLastRotation >= _timeRotation || _isInCollision)
            {
                RandomVector3(ref _dierectionOfRotate, -10, 10);
                _timeOfLastRotation = Time.time;
                _timeRotation = Random.Range(3, 6);
                _isInCollision = false;
            }
            _dierectionOfRotate.y = 0;
            Quaternion rotate = Quaternion.LookRotation(_dierectionOfRotate);
            Quaternion lerpRotate = Quaternion.Slerp(_enemyTr.rotation, rotate, _speedOfRotate * Time.fixedDeltaTime);
            _myRb.MoveRotation(lerpRotate);
        }
    }

    private bool IsMinDistanse(float minDistance)
    {
        float distance = Vector3.Distance(_enemyTr.position, _playerTr.position);
        if (minDistance >= distance)
            return true;
        else return false;
    }
    public void RandomVector3(ref Vector3 vector, int minValye, int maxValye)
    {
        vector.x = Random.Range(minValye, maxValye);
        vector.y = Random.Range(minValye, maxValye);
        vector.z = Random.Range(minValye, maxValye);

    }

    public void Attack(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _player.Hp--;
            Destroy(gameObject);
        }
        _isInCollision = true;
    }
}
