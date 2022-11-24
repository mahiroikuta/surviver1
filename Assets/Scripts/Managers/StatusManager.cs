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
            status.hp = status.maxHp;
            status.atk += 5;
            status.bulletSpeed += 5;
            status.speedLevel += 1;
            status.exp = 0;
        }
    }
}
