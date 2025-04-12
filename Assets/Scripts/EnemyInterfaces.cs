using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyInterfaces {}
public interface IEnemyFollow 
{
    public void FollowTarget();
}
public interface IEnemyRandomMove 
{
    public void Moving();
}
public interface IEnemyRotate 
{
    public void LookRotate();
}
public interface IEnemyRandomRotate 
{
    public void RandomRotate();
}
public interface IEnemyAttack 
{
    public void Attack(Collision collision);
}


