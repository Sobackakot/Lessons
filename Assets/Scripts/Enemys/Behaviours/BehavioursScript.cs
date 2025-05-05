using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehavioursScript
{
}
public class EnemyFollowPlayer : EnemyLookRotate
{
    

    public EnemyFollowPlayer(EnemyBase enemy) : base(enemy) 
    {
    }
    private Transform _enemyTr;
    private Transform _playerTr;
    private Rigidbody _myRb;
  
    public override void FollowPlayer() 
    {
        _enemyTr = enemy._enemyTr;
        _playerTr = enemy._playerTr;
        if (enemy.IsFollowTarget)// заменил вызов проверок на свойство из EnemyBase
        {
           Moving(_playerTr.position - _enemyTr.position);
        }
    }

    public override void FixedUpdate()
    {
        FollowPlayer();
        LookRotate();
    }
    public override void EneterBexaviour()
    {
        
        _myRb = enemy._myRb;
    }

}
public class EnemyRandomMove : EnemyRandomRotate
{
    public EnemyRandomMove(EnemyBase enemy) : base(enemy)
    {

    }
    private Transform _enemyTr;
    private Transform _playerTr;
    private Rigidbody _myRb;
   
    

    public override void RandomMove()
    {
        _enemyTr = enemy._enemyTr;
        _playerTr = enemy._playerTr;
        if (enemy.IsRandomMove)// заменил вызов проверок на свойство из EnemyBase
        {
            Moving(_enemyTr.forward);
        }
    }

    public override void FixedUpdate()
    {
        RandomMove();
        RandomRotate();
    }
    public override void EneterBexaviour()
    {
        
        _myRb = enemy._myRb;
    }
}
public class EnemyMove : BehavioursEnemyBase
{
    
    public EnemyMove(EnemyBase enemy) : base(enemy)
    {
       
    }
    private Transform _enemyTr;
    private Transform _playerTr;
    private Rigidbody _myRb;
    private void CashLincs()
    {
        _enemyTr = enemy._enemyTr;
        _playerTr = enemy._playerTr;
        _myRb = enemy._myRb;
    }

    public override void Moving(Vector3 _dierectionOfMove) 
    {
        CashLincs();
        _myRb.MovePosition(_myRb.position + _dierectionOfMove * enemy._speedOfMove*Time.fixedDeltaTime);
    }

   
}
public class EnemyRotate : EnemyMove
{
    public EnemyRotate(EnemyBase enemy) : base(enemy)
    {
    }

    public override void Rotate(Quaternion quaternion) 
    {
        Quaternion lerpRotate = Quaternion.Slerp(enemy._enemyTr.rotation, quaternion, enemy._speedOfRotate * Time.fixedDeltaTime);
        enemy._myRb.MoveRotation(lerpRotate);
    }

   
}
public class EnemyLookRotate : EnemyRotate
{
    
    public EnemyLookRotate(EnemyBase enemy) : base(enemy)
    {
    }
        private Transform _enemyTr;
        private Transform _playerTr;
        private Rigidbody _myRb;
  

    public override void LookRotate() 
    {
        _enemyTr = enemy._enemyTr;
        _playerTr = enemy._playerTr;
        if (enemy.IsLookTarget) // заменил вызов проверок на свойство из EnemyBase
        {
            Vector3 dierection = _playerTr.position - _enemyTr.position;
            dierection.y = 0;
            Quaternion rotate = Quaternion.LookRotation(dierection);
            Rotate(rotate);
        }
    }

    public override void EneterBexaviour()
    {
        
        _myRb = enemy._myRb;
    }
    
    
}
public class EnemyRandomRotate : EnemyLookRotate
{
    public EnemyRandomRotate(EnemyBase enemy) : base(enemy)
    {
    }

    private float _time;
    private Transform _enemyTr;
    private Transform _playerTr;
    private Rigidbody _myRb;
    
    public override void RandomRotate()
    { 
        if (enemy.IsRandomRotate) // заменил везде вызовы проверок на свойство из EnemyBase
        { if (_time <= Time.time || enemy._isInCollision)
            {
                Vector3 _dierectionOfRotate = enemy.RandomVector3(-10, 10);
                _time = Time.time + Random.Range(3, 6);
            }
            Quaternion rotate = Quaternion.LookRotation(enemy._dierectionOfRotate);
            Rotate(rotate);
        }
    }

    public override void EneterBexaviour() 
    {
        _enemyTr = enemy._enemyTr;
        _playerTr = enemy._playerTr;
        _myRb = enemy._myRb;
    }
}
public class EnemyIdel : EnemyRandomRotate
{
    public EnemyIdel(EnemyBase enemy) : base(enemy)
    {
    }
    public override void EneterBexaviour()
    {
    }
    public override void ExidBexaviour()
    {
    }
    public override void FixedUpdate()
    {
    }
    public override void Update()
    {
        RandomRotate();
        LookRotate();
    }
    public override void LateUpdate()
    {
    }
}
