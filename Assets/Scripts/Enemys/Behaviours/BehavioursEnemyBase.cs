using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehavioursEnemyBase :
    IEnemyMove,
    IEnemyRotate,
    IEnemyRandomMove,
    IEnemyRandomRotate,
    IEnemyFollowTarget,
    IEnemyLookTarget,
    IEnemyIdel
{

    public BehavioursEnemyBase(EnemyBase enemy)
    {
        this.enemy = enemy;
    }
    public EnemyBase enemy { get; private set; }

    

    public virtual void FollowPlayer() { }

    

    public virtual void LookRotate() { }


    public virtual void Moving( Vector3 _dierectionOfRotate) { }
    

    public virtual void RandomMove() { }
    

    public virtual void RandomRotate() { }


    public virtual void Rotate(Quaternion quaternion) { }

    public virtual void EneterBexaviour()
    {
    }
    public virtual void ExidBexaviour()
    {
    }
    public virtual void FixedUpdate()
    {
    }
    public virtual void Update()
    {
    }
    public virtual void LateUpdate()
    {
    }
}
