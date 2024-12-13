using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableMovement : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //if enemy runs into the laser
        {
            Player P = collision.GetComponent<Player>();
            if (P != null)
            {
                P.canMove = true;
            }
        }
    }
}
