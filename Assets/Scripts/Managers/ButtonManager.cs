using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject healItem;
    public GameObject speedUpItem;
    public GameObject splitItem;
    Button btn;

    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        // startButton.onClick.AddListener(_gameEvent.)
    }

    public void onUpdate()
    {
        
    } 
}
