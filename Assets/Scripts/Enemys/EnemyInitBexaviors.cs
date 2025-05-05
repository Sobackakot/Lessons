using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInitBexaviors  
{
     
public IEnemyIdel idle { get; private set; }
public IEnemyMove move { get; private set; }
public IEnemyRotate rotate { get; private set; }
public IEnemyRandomMove ranMove { get; private set; }
public IEnemyRandomRotate ranRot { get; private set; }
public IEnemyFollowTarget followTar { get; private set; }
public IEnemyLookTarget loockTar { get; private set; }


public void InitIdleBehaviour(IEnemyIdel idle) => this.idle = idle;
public void InitMoveBehaviour(IEnemyMove move) => this.move = move;
public void InitRotateBehaviour(IEnemyRotate rotate) => this.rotate = rotate;
public void InitRandomMove(IEnemyRandomMove ranMove) => this.ranMove = ranMove;
public void InitRandomRotate(IEnemyRandomRotate ranRot) => this.ranRot = ranRot;
public void InitFollowTarget(IEnemyFollowTarget followTar) => this.followTar = followTar;
public void InitLoockTarget(IEnemyLookTarget lookTar) => this.loockTar = loockTar;
}
