using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

public class MainUpdate : MonoBehaviour
{
    private Dictionary<EnemyBase, EnemyStateHandler> statesHandler = new();
    private Dictionary<EnemyBase, EnemyInitBexaviors> behaviourHandler = new();
    private List<EnemyBase> _enemyBases = new();

    private void Awake()
    {
        _enemyBases.AddRange(FindObjectsOfType<EnemyBase>());
    }
    private void OnEnable()
    {
        
    }
    private void Start()
    {
        foreach(var enemy in _enemyBases)
        {
            var behaviour = new EnemyInitBexaviors();
            var state = new EnemyStateHandler();
            state?.SetState(new EnemyIdleState(behaviour.idle));
            InitBexaviours(enemy, behaviour);
            statesHandler[enemy] = state;
            behaviourHandler[enemy] = behaviour;
        }
    }
    private void OnDisable()
    {
    }
    void Update()
    {
        foreach (var behaviour in statesHandler.Values)
        {
            behaviour?.UpdateState();
        }
        foreach (var enemy in _enemyBases)// добавил вызов функции
            ChangeStates(enemy);

    }
    private void LateUpdate()
    {
        foreach (var behaviour in statesHandler.Values)
        {
            behaviour?.LateUpdateState();
        }
    }
    private void FixedUpdate()
    {
        foreach (var behaviour in statesHandler.Values)
        {
            behaviour?.FixedUpdateState();
        }
    }
    private void ChangeStates(EnemyBase e) // забыл вызвать функцию в update
    {
        var behaviour = behaviourHandler[e];
        var state = statesHandler[e];
        if (e.IsIdle)
        { 
            state?.SetState(new EnemyIdleState(behaviour.idle));// везде добавил опператор <?> для обработки исключеней 
        }
        else if (e.IsFollowTarget)
        {
            state?.SetState(new EnemyFollowStates(behaviour.followTar));
        }
        else if (e.IsRandomMove)
        {
            state?.SetState(new EnemyMoveState(behaviour.ranMove));
        }
    }

    private void InitBexaviours(EnemyBase e, EnemyInitBexaviors bex)
    {
        bex.InitIdleBehaviour(new EnemyIdel(e));
        bex.InitRandomMove(new EnemyRandomMove(e));
        bex.InitRandomRotate(new EnemyRandomRotate(e));
        bex.InitFollowTarget(new EnemyFollowPlayer(e));
        bex.InitLoockTarget(new EnemyLookRotate(e));
    }
}
