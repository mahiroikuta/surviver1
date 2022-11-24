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
        _gameEvent.useItem += useItem;
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

    public void useItem(ItemType itemType)
    {
        Status playerStatus = _gameState.player.GetComponent<Status>();
        switch ( itemType )
        {
            case ItemType.Split:
                playerStatus.splitLevel += 1;
                break;
            case ItemType.SpeedUp:
                playerStatus.bulletSpeed += 5;
                playerStatus.speedLevel += 1;
                break;
            case ItemType.Heal:
                playerStatus.hp += playerStatus.maxHp/3;
                if ( playerStatus.hp > playerStatus.maxHp ) playerStatus.hp = playerStatus.maxHp;
                break;
        }
    }
}
