using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField]
    public GameState _gameState;

    public GameEvent _gameEvent;
    public GameRule _gameRule;
    public GameStatus _gameStatus;

    public PlayerSponeManager playerSponeManager;
    public PlayerShotManager playerShotManager;
    public AttackHitManager attackHitManager;
    public HpBarManager hpBarManager;
    public EnemyMoveManager enemyMoveManager;
    public EnemySponeManager enemySponeManager;
    public EnemyHitManager enemyHitManager;
    public StatusManager statusManager;

    void Awake()
    {
        _gameState.isShooting = false;
        _gameRule.setUp(_gameState, _gameEvent);
        _gameState.gameStatus = GameStatus.IsPlaying;

        playerSponeManager.setUp(_gameState, _gameEvent);
        playerShotManager.setUp(_gameState, _gameEvent);
        attackHitManager.setUp(_gameState, _gameEvent);
        hpBarManager.setUp(_gameState, _gameEvent);
        enemyMoveManager.setUp(_gameState, _gameEvent);
        enemySponeManager.setUp(_gameState, _gameEvent);
        enemyHitManager.setUp(_gameState, _gameEvent);
        statusManager.setUp(_gameState, _gameEvent);
    }

    void Start()
    {

    }

    void Update()
    {
        if ( _gameState.gameStatus != GameStatus.IsPlaying ) return;
        _gameState = playerShotManager.onUpdate();
        _gameState = attackHitManager.onUpdate();
        _gameState = hpBarManager.onUpdate();
        _gameState = enemyMoveManager.onUpdate();
        _gameState = enemySponeManager.onUpdate();
        _gameState = enemyHitManager.onUpdate();
        _gameState = statusManager.onUpdate();
        if ( Input.GetMouseButtonDown(0) ) playerShotManager.shot();
    }
}
