using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScr : MonoBehaviour
{
    [SerializeField]
    private int maxLives = 1;

    private int curLives;

    private BlockManager _manager;

    public void SetBlockManager(BlockManager manager) {
        _manager = manager;
    }

    void Start()
    {
        curLives = maxLives;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallScr ball = collision.gameObject.GetComponent<BallScr>();
        if (ball)
        {
            TakeHit(ball.Damage);
        }
    }

    private void TakeHit(int damage)
    {
        curLives -= damage;
        if (curLives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _manager.KillBlock(this);
    }
}
