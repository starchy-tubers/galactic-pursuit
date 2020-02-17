using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script is broken.
public class EnemyHurt : MonoBehaviour
{
    public int enemyHealth = 5;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet")) 
        {
            enemyHealth -= 1;
            if (enemyHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}