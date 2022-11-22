using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSponeManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        playerSpone();
    }

    public GameState onUpdate()
    {
        return _gameState;
    }

    public void playerSpone()
    {
        GameObject player = GameObject.Instantiate(_gameState.player, _gameState.player.transform.position, Quaternion.identity) as GameObject;
    }
}