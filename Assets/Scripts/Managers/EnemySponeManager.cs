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

    public void onUpdate()
    {
        sponeEnemy();
    }

    public void sponeEnemy()
    {
        _gameState.sponeTime += Time.deltaTime;
        if ( _gameState.sponeTime < 3 ) return;
        Vector3 sponePos = sponePosition();
        GameObject enemy = GameObject.Instantiate(_gameState.enemy, sponePos, Quaternion.identity) as GameObject;
        Status eStatus = enemy.GetComponent<Status>();
        Status pStatus = _gameState.player.GetComponent<Status>();
        enemyStatus(eStatus, pStatus);
        _gameState.enemys.Add(enemy);
        _gameState.sponeTime = 0;
    }

    Vector3 sponePosition()
    {
        int num = Random.Range(1,5);
        float x = 0f;
        float y = 0f;
        float z = 0f;
        switch(num)
        {
            case 1:
                x = Random.Range(-14.0f, 14.0f);
                y = 7.5f;
                break;
            case 2:
                x = Random.Range(-14.0f, 14.0f);
                y = -7.5f;
                break;
            case 3:
                x = 14.0f;
                y = Random.Range(-7.5f, 7.5f);
                break;
            case 4:
                x = -14.0f;
                y = Random.Range(-7.5f, 7.5f);
                break;
        }
        Vector3 pos = new Vector3(x,y,z);
        return pos;
    }

    void enemyStatus(Status eStatus, Status pStatus)
    {
        eStatus.level = Random.Range(1,pStatus.level);
        switch ( eStatus.level )
        {
            case 1:
                eStatus.maxHp = 10;
                eStatus.hp = eStatus.maxHp;
                eStatus.atk = 5;
                eStatus.bulletSpeed = 1;
                eStatus.speedLevel = 1;
                break;
            case 2:
                eStatus.maxHp = 45;
                eStatus.hp = eStatus.maxHp;
                eStatus.atk = 10;
                eStatus.bulletSpeed = 2;
                eStatus.speedLevel = 2;
                break;
            case 3:
                eStatus.maxHp = 135;
                eStatus.hp = eStatus.maxHp;
                eStatus.atk = 15;
                eStatus.bulletSpeed = 3;
                eStatus.speedLevel = 3;
                break;
        }
    }
}
