using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidAppear : MonoBehaviour
{
    public GameObject Asteroid;
    public GameObject BulletsPowerUp;
    bool canAppear = true;
    float RandomNum;
    private const float velX = 0;
    public float velY = -1f;
    Rigidbody2D rb;
    int asteroidHealth = 10;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            asteroidHealth -= 1;
            if (asteroidHealth == 0) {
            Destroy(gameObject);
                if (Random.value > 0.85)
                {
                    Instantiate(BulletsPowerUp, transform.position, transform.rotation);
                }
          }
       }
    }
    private void Update()
    {
        RandomNum = Random.Range(-2.4f, 2.4f);
        if (!canAppear) return;
        canAppear = false;
        StartCoroutine(noAppear());
        rb.velocity = new Vector2(velX, velY);
    }

    private IEnumerator noAppear()
    {
        yield return new WaitForSeconds((float)RandomHandler.GetRandomNumber2());
        Instantiate(Asteroid, new Vector2(RandomNum, 5), transform.rotation);
        canAppear = true;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
