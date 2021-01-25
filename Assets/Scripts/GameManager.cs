using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager 
{
    public const int DEFAULT_PLAYER_LIVES = 3;
    public int PlayerLives {
        get {
            return _playerLives;
        }
    }

    public delegate void LivesHandler(int lives);
    public event LivesHandler LivesChanged;

    private int _playerLives = DEFAULT_PLAYER_LIVES;

    private static GameManager _instance;
    private BallsManager _ballsManager;
    private BlockManager _blockManager;
    private GameManager() {
        LivesChanged?.Invoke(_playerLives);
    }

    public static GameManager getInstance() {
        if (_instance == null)
            _instance = new GameManager();
        return _instance;
    } 

    public void WinGame() {
        SceneManager.LoadScene("WinGame");
    }

    public void ChangePlayerLives(int count)
    {
        _playerLives += count;
        LivesChanged?.Invoke(_playerLives);
        if (_playerLives <= 0)
        {
            GameOver();
        }
    }

    public void SetBallsManager(BallsManager manager) {
        _ballsManager = manager;
    }
    public void SetBlocksManager(BlockManager manager) {
        _blockManager = manager;
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

  
}
