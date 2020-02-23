using UnityEngine;

public class ShipBullet : MonoBehaviour
{
    public float velY = 5f;
    private const float velX = 0;
    Rigidbody2D rb;

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
        if (col.gameObject.CompareTag("GreenEnemy")|| col.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

