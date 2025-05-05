using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyInterfaces {}
public interface IEnemyFollowTarget : IBexaviourHandler
{
    void FollowPlayer();
}
public interface IEnemyRandomMove : IBexaviourHandler
{
    public void RandomMove();
}
public interface IEnemyMove : IBexaviourHandler
{
    void Moving(Vector3 _dierectionOfRotate);
}
public interface IEnemyRotate : IBexaviourHandler
{
    public void Rotate(Quaternion quaternion);
}
public interface IEnemyLookTarget : IBexaviourHandler
{
    public void LookRotate();
}
public interface IEnemyIdel : IBexaviourHandler
{
    
}
public interface IEnemyRandomRotate : IBexaviourHandler
{
    public void RandomRotate();
}
public interface IEnemyAttack : IBexaviourHandler
{
    public void Attack(Collision collision);
}
public interface IBexaviourHandler
{
    void Update();
    void FixedUpdate();
    void LateUpdate();
    void EneterBexaviour();
    void ExidBexaviour();


}



