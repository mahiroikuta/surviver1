using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;

        _gameEvent.bulletHitEnemy += damageEnemy;
        _gameEvent.enemyHitPlayer += damagePlayer;
    }

    public void damageEnemy(GameObject playerBullet, GameObject enemy)
    {
        Status enemyStatus = enemy.GetComponent<Status>();
        Status playerStatus = _gameState.player.GetComponent<Status>();
        enemyStatus.hp = enemyStatus.hp - playerStatus.atk;
        _gameState.playerBullets.Remove(playerBullet);
        Destroy(playerBullet.gameObject);
        if ( enemyStatus.hp <= 0 )
        {
            _gameState.enemys.Remove(enemy);
            Destroy(enemy.gameObject);
            playerStatus.exp += 1;
        }
    }

    public void damagePlayer(GameObject enemy)
    {
        Status pStatus = _gameState.player.GetComponent<Status>();
        Status eStatus = enemy.GetComponent<Status>();
        pStatus.hp = pStatus.hp - eStatus.atk;
        _gameState.enemys.Remove(enemy);
        Destroy(enemy.gameObject);
        if ( pStatus.hp <= 0 )
        {
            _gameState.gameStatus = GameStatus.GameOver;
        }
    }
}
