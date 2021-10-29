using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private bool destroying;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!destroying && collision.gameObject.CompareTag("Enemy"))
        {
            destroying = true;

            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.CompareTag("Enemy"))
    //     {
    //         Destroy(gameObject);
    //         LevelManager.instance.Respawn();
    //     }
    // }
}
