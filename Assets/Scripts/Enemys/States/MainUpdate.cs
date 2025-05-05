using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUpdate : MonoBehaviour
{
    private Dictionary<EnemyBase, EnemyStateHandler> _enemyStateHans = new();
    private Dictionary<EnemyBase, EnemyInitBexaviors> _initBexaviors = new();
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
        foreach(EnemyBase e in _enemyBases)
        {
            var enemyBex = new EnemyInitBexaviors();
            var enemyState = new EnemyStateHandler();
            enemyState?.SetState(new EnemyIdleState(enemyBex.idle));
            InitBexaviours(e, enemyBex);
        }
    }
    private void OnDisable()
    {
    }
    void Update()
    {
        foreach (EnemyStateHandler eSH in _enemyStateHans.Values)
        {
            eSH?.UpdateState();
        }
        foreach (var enemy in _enemyBases)// добавил вызов функции
            ChangeStates(enemy);

    }
    private void LateUpdate()
    {
        foreach (EnemyStateHandler eSH in _enemyStateHans.Values)
        {
            eSH?.LateUpdateState();
        }
    }
    private void FixedUpdate()
    {
        foreach (EnemyStateHandler eSH in _enemyStateHans.Values)
        {
            eSH?.FixedUpdateState();
        }
    }
    private void ChangeStates(EnemyBase e) // забыл вызвать функцию в update
    {
        var bex = _initBexaviors[e];
        var state = _enemyStateHans[e];
        if (e.IsIdle)
        { 
            state?.SetState(new EnemyIdleState(bex.idle));// везде добавил опператор <?> для обработки исключеней 
        }
        else if (e.IsFollowTarget)
        {
            state?.SetState(new EnemyFollowStates(bex.followTar));
        }
        else if (e.IsRandomMove)
        {
            state?.SetState(new EnemyMoveState(bex.ranMove));
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
