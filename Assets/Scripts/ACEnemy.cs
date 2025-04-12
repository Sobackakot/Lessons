using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ACEnemy : MonoBehaviour
{
    protected Transform _playerTr;

    private void Start()
    {
        _playerTr = FindObjectOfType<Player>().transform;
    }

    public void Move(Vector3 target, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void Shoot(GameObject gameObject, Vector3 target, float speedOfBullet)
    {
        GameObject gameObj = Instantiate(gameObject, transform);
        gameObj.transform.position = Vector3.MoveTowards(transform.position, target, speedOfBullet * Time.deltaTime);
    }    
}
