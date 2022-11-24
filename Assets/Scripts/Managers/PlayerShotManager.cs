using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerShotManager : MonoBehaviour
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

    public void shot()
    {
        if ( _gameState.isShooting ) return;
        Vector3 shotForward = shotForwardGet();
        // 打つ処理
        _gameState.isShooting = true;
        StartCoroutine("shotDelay", shotForward);
    }

    IEnumerator shotDelay(Vector3 shotForward)
    {
        GameObject playerBullet = GameObject.Instantiate(_gameState.playerBullet, _gameState.player.transform.position, Quaternion.identity) as GameObject;
        _gameState.playerBullets.Add(playerBullet);
        Rigidbody rig = playerBullet.GetComponent<Rigidbody>();
        Status status = _gameState.player.GetComponent<Status>();
        rig.velocity = shotForward * status.bulletSpeed;
        yield return new WaitForSeconds(1f/(float)status.level);
        _gameState.isShooting = false;
    }

    Vector3 shotForwardGet()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 15;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 shotForward = Vector3.Scale((mouseWorldPos - _gameState.player.transform.position), new Vector3(1, 1, 0)).normalized;
        return shotForward;
    }
}
