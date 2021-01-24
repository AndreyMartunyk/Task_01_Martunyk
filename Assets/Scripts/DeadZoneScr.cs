using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneScr : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BallScr>())
        {
            GameManager.getInstance().KillTheBall(collision.gameObject);
        }

        Destroy(collision);
    }
}
