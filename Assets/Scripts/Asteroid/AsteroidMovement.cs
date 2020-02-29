using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public GameObject Asteroid;
    public GameObject BulletsPowerUp;

    float RandomNum;
    private const float velX = 0;
    public float velY = -3f;
    Rigidbody2D rb;
    int asteroidHealth = 10;

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
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            asteroidHealth -= 1;
            if (asteroidHealth == 0)
            {
                Destroy(gameObject);
                if (Random.Range(0.00f, 1.00f) < 0.25)
                {
                    Instantiate(BulletsPowerUp, transform.position, transform.rotation);
                }
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}