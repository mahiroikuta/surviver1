using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        Status playerStatus = _gameState.player.GetComponent<Status>();
        playerStatus.hp = playerStatus.maxHp;
    }

    public void onUpdate()
    {
        playerHpBar();
        enemyHpBar();
    }

    public void playerHpBar()
    {
        Status playerStatus = _gameState.player.GetComponent<Status>();
        HpBar playerHpBar = _gameState.player.GetComponent<HpBar>();
        int nowPlayerHp = playerStatus.hp;
        int maxPlayerHp = playerStatus.maxHp;
        playerHpBar.hpBar.value = (float)nowPlayerHp / (float)maxPlayerHp;
    }

    public void enemyHpBar()
    {
        if ( _gameState.enemys.Count == 0 ) return;
        int count = _gameState.enemys.Count;
        for ( int i=count-1 ; i>=0 ; i-- )
        {
            count = _gameState.enemys.Count;
            GameObject enemy = _gameState.enemys[i];
            Status enemyStatus = enemy.GetComponent<Status>();
            HpBar enemyHpBar = enemy.GetComponent<HpBar>();
            int nowEnemyHp = enemyStatus.hp;
            int maxEnemyHp = enemyStatus.maxHp;
            enemyHpBar.hpBar.value = (float)nowEnemyHp / (float)maxEnemyHp;
        }
    }
}
