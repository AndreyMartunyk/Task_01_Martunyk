using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScr : MonoBehaviour
{
    [SerializeField]
    private int maxLives = 1;

    private int curLives;

    void Start()
    {
        curLives = maxLives;
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("coll enter 2d " + collision.gameObject.name);
        BallScr ball = collision.gameObject.GetComponent<BallScr>();
        if (ball)
        {
            TakeHit(ball.Damage);
        }
    }

    private void TakeHit(int damage)
    {
        Debug.Log("Take hit - " + damage.ToString());
        curLives -= damage;
        if (curLives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("I am die!!");
        Destroy(gameObject);
    }
}
