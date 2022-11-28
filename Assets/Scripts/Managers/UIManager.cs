using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        _gameState.startPanel.SetActive(true);
        _gameState.levelUpPanel.SetActive(false);
        _gameState.resultPanel.SetActive(false);
    }

    public void onUpdate()
    {
        if ( _gameState.gameStatus == GameStatus.ItemChoosing ) _gameState.levelUpPanel.SetActive(true);
        else if ( _gameState.gameStatus == GameStatus.Retry ) _gameState.startPanel.SetActive(true);
        else if ( _gameState.gameStatus == GameStatus.Result ) _gameState.resultPanel.SetActive(true);
    }

    
}
