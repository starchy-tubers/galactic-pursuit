using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPowerUp : MonoBehaviour
{
    Rigidbody2D rb;

    private const float velX = 0;

    public float velY = -3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ship"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
