using UnityEngine;

public class BallsManager : MonoBehaviour
{
    private const float BALL_Y_OFFSET_TO_PLAYER = 0.5f;

    [SerializeField]
    private GameObject _ballPref;
    [SerializeField]
    private GameObject _player;
    private int _countBalls = 1;

    private void Start() {
        GameManager.getInstance().SetBallsManager(this);
        SpawnBallWithPlayer();
    }

    public void KillTheBall(BallScr ball) {
        --_countBalls;
        if (_countBalls <= 0) {
            GameManager.getInstance().ChangePlayerLives(-1);
            SpawnBallWithPlayer();
        }
        Destroy(ball);
    }
    public void AddTheBall() {
        ++_countBalls;
    }

    private Vector2 GetStartBallPos() {
        return new Vector2(_player.transform.position.x, _player.transform.position.y + BALL_Y_OFFSET_TO_PLAYER);
    }

    private void SpawnBallWithPlayer() {
        GameObject ball = Instantiate(_ballPref, GetStartBallPos(), Quaternion.identity, _player.transform);
        ball.GetComponent<BallScr>().SetBallManager(this);
    }




}
