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
        // _gameEvent.bulletHitPlayer += damagePlayer;
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
        }
    }

    // public void damagePlayer(GameObject enemyBullet, GameObject player)
    // {
    //     Status playerStatus = _gameState.player.GetComponent<Status>();
    //     Status enemyStatus = enemy.GetComponent<Status>();
    //     playerStatus.hp = playerStatus.hp - enemyStatus.atk;
    //     _gameState.enemyBullets.Remove(enemyBullet);
    //     Destroy(enemyBullet.gameObject);
    //     if ( playerStatus.hp <= 0 )
    //     {
    //         _gameState.gameStatus = GameStatus.GameOver;
    //     }
    // }
}
