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
    public UIManager UIManager;

    public PlayerSponeManager playerSponeManager;
    public PlayerShotManager playerShotManager;
    public AttackHitManager attackHitManager;
    public HpBarManager hpBarManager;
    public EnemyMoveManager enemyMoveManager;
    public EnemySponeManager enemySponeManager;
    public EnemyHitManager enemyHitManager;
    public StatusManager statusManager;

    public StartButtonManager startButtonManager;
    public RetryButtonManager retryButtonManager;
    public SplitButtonManager splitButtonManager;
    public SpeedUpButtonManager speedUpButtonManager;
    public HealButtonManager healButtonManager;

    void Awake()
    {
        _gameState.isShooting = false;
        _gameRule.setUp(_gameState, _gameEvent);
        _gameState.gameStatus = GameStatus.Title;
        UIManager.setUp(_gameState, _gameEvent);

        playerSponeManager.setUp(_gameState, _gameEvent);
        playerShotManager.setUp(_gameState, _gameEvent);
        attackHitManager.setUp(_gameState, _gameEvent);
        hpBarManager.setUp(_gameState, _gameEvent);
        enemyMoveManager.setUp(_gameState, _gameEvent);
        enemySponeManager.setUp(_gameState, _gameEvent);
        enemyHitManager.setUp(_gameState, _gameEvent);
        statusManager.setUp(_gameState, _gameEvent);

        startButtonManager.setUp(_gameState, _gameEvent);
        retryButtonManager.setUp(_gameState, _gameEvent);
        splitButtonManager.setUp(_gameState, _gameEvent);
        speedUpButtonManager.setUp(_gameState, _gameEvent);
        healButtonManager.setUp(_gameState, _gameEvent);
    }

    void Start()
    {

    }

    void Update()
    {
        UIManager.onUpdate();
        attackHitManager.onUpdate();
        enemyHitManager.onUpdate();
        if ( _gameState.gameStatus == GameStatus.Retry ) 
        {
            Awake();
            _gameState.gameStatus = GameStatus.IsPlaying;
        }
        if ( _gameState.gameStatus != GameStatus.IsPlaying ) return;
        playerShotManager.onUpdate();
        hpBarManager.onUpdate();
        enemyMoveManager.onUpdate();
        enemySponeManager.onUpdate();
        statusManager.onUpdate();
        if ( Input.GetMouseButtonDown(0) ) playerShotManager.shot();
    }
}
