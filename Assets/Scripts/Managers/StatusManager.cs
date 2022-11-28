using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
    }

    public void onUpdate()
    {
        checkExp();
    }

    public void checkExp()
    {
        Status status = _gameState.player.GetComponent<Status>();
        if ( status.exp == status.level*3 )
        {
            _gameState.gameStatus = GameStatus.ItemChoosing;
            status.level += 1;
            status.maxHp += 50;
            status.hp += 50;
            status.atk += 5;
            status.bulletSpeed += 2;
            status.speedLevel += 1;
            status.exp = 0;
        }
    }

    public void playerInitialize()
    {
        Status status = _gameState.player.GetComponent<Status>();
        HpBar playerHpBar = _gameState.player.GetComponent<HpBar>();
        status.level = 1;
        status.maxHp = 50;
        status.hp = 50;
        status.atk = 5;
        status.bulletSpeed = 5;
        status.speedLevel = 1;
        status.splitLevel = 0;
        status.exp = 0;
        playerHpBar.hpBar.value = 1;
    }
}
