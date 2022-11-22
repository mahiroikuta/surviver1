using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySponeManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
    }

    public GameState onUpdate()
    {
        return _gameState;
    }

    public void sponeEnemy()
    {
        
    }
}
