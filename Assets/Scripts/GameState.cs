using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameStatus
{
    Title,
    IsPlaying,
    ItemChoosing,
    GameOver,
}

[System.Serializable]
public class GameState
{
    public GameObject player;
    public GameObject playerBullet;
    public Slider playerHpBar;

    public GameObject enemy;
    public GameObject enemyBullet;
    public Slider enemyHpBar;

    public int playTime;
    [System.NonSerialized]
    public float sponeTime;

    // UI
    public GameObject startPanel;
    public GameObject levelUpPanel;
    public GameObject resultPanel;

    [System.NonSerialized]
    public GameStatus gameStatus;

    [System.NonSerialized]
    public bool isShooting;

    [System.NonSerialized]
    public List<GameObject> playerBullets = new List<GameObject>();

    [System.NonSerialized]
    public List<GameObject> enemys = new List<GameObject>();
}
