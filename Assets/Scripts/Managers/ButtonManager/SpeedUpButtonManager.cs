using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpButtonManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        _gameState.speedUpButton.onClick.AddListener(useHeal);
    }

    void useHeal()
    {
        _gameEvent.useItem?.Invoke(ItemType.SpeedUp);
    }
}
