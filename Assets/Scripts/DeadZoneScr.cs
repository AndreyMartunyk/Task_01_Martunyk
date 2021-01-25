using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneScr : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BallScr>())
        {
            collision.gameObject.GetComponent<BallScr>().Die();
        }
        else {
            Destroy(collision);
        } 
    }
}
