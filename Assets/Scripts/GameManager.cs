using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform startBallPos;
    [SerializeField]
    public GameObject _ballPref;
    [SerializeField]
    private int _playerLives = 3;
    [SerializeField]
    private Text _livesText;

    private int _countBalls = 1;

    private static GameManager _instance;

    private GameManager()
    { }

    private void Start() {
        _instance = this;
        SpawnBall();
        UpdateLivesUI();
    }

    public static GameManager getInstance()
    {
        if (_instance == null)
            _instance = new GameManager();
        return _instance;
    }

    public void KillTheBall(GameObject ball)
    {
        --_countBalls;
        if (_countBalls <= 0)
        {
            ChangePlayerLives(-1);
            SpawnBall();
        }
        Destroy(ball);
    }

    private GameObject SpawnBall()
    {
        Debug.Log(_ballPref == null);
        return Instantiate(_ballPref, startBallPos.position, Quaternion.identity);
    }

    public void AddTheBall()
    {
        ++_countBalls;
    }

    private void ChangePlayerLives(int count)
    {
        _playerLives += count;
        UpdateLivesUI();
        if (_playerLives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void UpdateLivesUI()
    {
        _livesText.text = _playerLives.ToString();
    }
}
