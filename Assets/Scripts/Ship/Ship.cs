using UnityEngine;

public class Ship : MonoBehaviour
{
    public int shipHealth = 3;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EnemyBullet"))
        {
            shipHealth -= 1;

            if (shipHealth == 0) {

                Destroy(gameObject);
            }
        }
    }
}