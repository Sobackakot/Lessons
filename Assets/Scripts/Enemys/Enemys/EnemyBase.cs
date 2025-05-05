using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour 
{
public Rigidbody _myRb { get; private set; }
    public Transform _playerTr { get; private set; }
    public Transform _enemyTr { get; private set; }
    [field: SerializeField]
    public  float _speedOfRotate { get; private set; } = 1;
    [field: SerializeField]
    public  float _speedOfMove { get; private set; } = 5;
    [field: SerializeField]
    public  float _minDistanceLookTarget { get; private set; } = 25;
    [field: SerializeField]
    public  float _minDistanceFollowTarget { get; private set; } = 15;
    [field: SerializeField]
    public float _timeOfLastRotation;
    [field: SerializeField]
    public float _timeRotation { get; private set; }
    [field: SerializeField]
    public bool _isInCollision { get; private set; }
    [field: SerializeField]
    public Vector3 _dierectionOfRotate { get; private set; } = Vector3.zero;
    public bool IsFollow { get; private set; }
    public bool IsRandomMove { get; private set; }
    public bool IsIdel { get; private set; } = true;

    void Awake()
    {
        _myRb = GetComponent<Rigidbody>();
        _timeRotation = Random.Range(3, 6);
        _enemyTr = GetComponent<Transform>();
        _playerTr = FindObjectOfType<Player>().transform;
    }
    private void Update()
    {
        IsRandomMove = !IsIdel && !IsFollow;
        IsFollow = IsMinDistanse(_minDistanceFollowTarget);
        IsIdel = IsMinDistanse(_minDistanceLookTarget);
    }
    public bool IsMinDistanse(float minDistance)
    {
        float distance = Vector3.Distance(_enemyTr.position, _playerTr.position);
        if (minDistance >= distance)
            return true;
        else return false;
    }
    public Vector3 RandomVector3( int minValye, int maxValye)
    {
        float x = Random.Range(minValye, maxValye);
        float z = Random.Range(minValye, maxValye);
        return new Vector3(x, 0, z);
    }
    


    //public void Attack(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        _player.Hp--;
    //        Destroy(gameObject);
    //    }
    //    _isInCollision = true;
    //}
    
}
