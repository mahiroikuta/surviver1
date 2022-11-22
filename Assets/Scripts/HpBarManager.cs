using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        Status playerStatus = _gameState.player.GetComponent<Status>();
        playerStatus.hp = playerStatus.maxHp;
    }

    public GameState onUpdate()
    {
        hpBar();
        return _gameState;
    }

    public void hpBar()
    {
        Status playerStatus = _gameState.player.GetComponent<Status>();
        Slider playerHpBar = _gameState.playerHpBar;
        int nowPlayerHp = playerStatus.hp;
        int maxPlayerHp = playerStatus.maxHp;
        Debug.Log(nowPlayerHp);
        Debug.Log(maxPlayerHp);
        playerHpBar.value = (float)nowPlayerHp / (float)maxPlayerHp;
        Debug.Log(playerHpBar.value);
    }
}
