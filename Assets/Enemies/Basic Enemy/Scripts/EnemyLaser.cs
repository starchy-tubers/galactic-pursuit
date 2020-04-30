using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    private const float velX = 0;

    private Rigidbody2D rb;
    public float velY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ship") ||
            col.gameObject.CompareTag("Shield") ||
            col.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}