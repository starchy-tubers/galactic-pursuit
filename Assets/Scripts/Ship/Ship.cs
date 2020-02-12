using UnityEngine;

public class Ship : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        }
    }
}