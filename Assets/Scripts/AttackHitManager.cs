using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitManager : MonoBehaviour
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
        playerBulletHit();
        return _gameState;
    }

    public void playerBulletHit()
    {
        if ( _gameState.playerBullets.Count == 0 ) return;
        int count = _gameState.playerBullets.Count;
        for ( int i=count-1 ; i>=0 ; i-- )
        {
            count = _gameState.playerBullets.Count;
            GameObject playerBullet = _gameState.playerBullets[i];
            RaycastHit hit;
            Rigidbody rig = playerBullet.GetComponent<Rigidbody>();
            if ( Physics.SphereCast(playerBullet.transform.position, 1.0f, rig.velocity, out hit, 0.3f, LayerMask.GetMask("Default")) )
            {
                bulletHitEnemy(playerBullet, hit);
            }
            Debug.DrawRay(playerBullet.transform.position, rig.velocity, Color.red);
        }
    }

    void bulletHitEnemy(GameObject playerBullet, RaycastHit hit)
    {
        GameObject enemy;
        if ( hit.collider.gameObject.GetComponent<Status>() != null )
        {
            enemy = hit.collider.gameObject;
            if ( enemy != null )
            {
                _gameEvent.bulletHitEnemy?.Invoke(playerBullet, enemy);
            }
        }
        else
        {
            _gameState.playerBullets.Remove(playerBullet);
            Destroy(playerBullet.gameObject);
        }
    }

    void bulletHitPlayer(GameObject enemyBullet, RaycastHit hit)
    {
        GameObject player;
        player = hit.collider.gameObject.GetComponent<GameObject>();
        if ( player != null )
        {
            _gameEvent.bulletHitPlayer?.Invoke(enemyBullet, player);
        }
    }


}