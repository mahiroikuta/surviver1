using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveManager : MonoBehaviour
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
        moving();
        return _gameState;
    }

    public void moving()
    {
        if ( _gameState.enemys.Count == 0 ) return;
        int count = _gameState.enemys.Count;
        for ( int i=count-1 ; i>=0 ; i-- )
        {
            count = _gameState.enemys.Count;
            GameObject enemy = _gameState.enemys[i];
            Status enemyStatus = enemy.GetComponent<Status>();
            float speed = enemyStatus.speedLevel/500;
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, _gameState.player.transform.position, speed);
        }
    }
}
