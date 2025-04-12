using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOfElement : ACEnemy
{
    [SerializeField]
    private float _followDistance;
    [SerializeField]
    private float _shootDistance;
    [SerializeField]
    private float _speed;
    private Vector3 _targetForMove;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _timeBetweenShots = 0.8f;
    private float _speedOfBullet = 5;
    private float _lastShotTime;
    private void Update()
    {
        if (IsShootDistance() && Time.time - _lastShotTime >= _timeBetweenShots)
        {
            Shoot(_bullet, _playerTr.position, _speedOfBullet);
            _lastShotTime = Time.time;
        }
        else if (IsFollowDistanse())
        {
            Move(_playerTr.position, _speed);
            
        }
        else
            Move(_targetForMove, _speed);

    }
    private void Start()
    {
        _targetForMove = transform.position;
    }
    private bool IsFollowDistanse()
    {
        float distance = Vector3.Distance(_playerTr.position, transform.position);
        if (_followDistance > distance)
            return true;
        else return false;
    }
    private bool IsShootDistance()
    {
        float distance = Vector3.Distance(_playerTr.position, transform.position);
        if (_shootDistance > distance)
            return true;
        else return false;
    }

}
