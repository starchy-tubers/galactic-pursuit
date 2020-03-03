using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public GameObject Asteroid;
    public GameObject BulletsPowerUp;
    public GameObject HealthPowerUp;
    float RandomNum;
    private const float velX = 0;
    public float velY = -3f;
    Rigidbody2D rb;
    int asteroidHealth = 10;
    bool canAppear = true;
    float powerUpDelay = 1.0f;
    float bulletsPowerUpChance = 0.25f;
    float healthPowerUpChance = 0.25f;

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
            int shipHealth = GameObject.Find("Ship").GetComponent<Ship>().shipHealth;
            asteroidHealth -= 1;
            if (asteroidHealth == 0)
            {
                Destroy(gameObject);

                if (Random.Range(0.00f, 1.00f) < bulletsPowerUpChance)
                {
                    Instantiate(BulletsPowerUp, transform.position, transform.rotation);
                    canAppear = false;
                    StartCoroutine(NoAppear());
                }
                if (Random.Range(0.00f, 1.00f) < healthPowerUpChance && shipHealth < 10 && canAppear)
                {
                    Instantiate(HealthPowerUp, transform.position, transform.rotation);
                }
            }
        }

    }

    private IEnumerator NoAppear()
    {
        yield return new WaitForSeconds(powerUpDelay);
        canAppear = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
