using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private const float velX = 0;

    private int asteroidHealth = 10;

    private AudioSource[] audioSources;
    public GameObject BulletsPowerUp;

    private readonly float bulletsPowerUpChance = 0.5f;

    private bool canAppear = true;

    private AudioClip explosionSound;

    public GameObject HealthPowerUp;

    private readonly float healthPowerUpChance = 0.5f;

    private AudioClip laserImpactSound;

    private readonly float powerUpDelay = 1.0f;
    private float RandomNum;

    private Rigidbody2D rb;

    public GameObject ShieldPowerUp;

    private readonly float shieldPowerUpChance = 0.5f;

    public float velY = -3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioSources = GetComponents<AudioSource>();

        laserImpactSound = audioSources[0].clip;
        explosionSound = audioSources[1].clip;
    }

    private void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            var shipHealth =
                GameObject.Find("Ship").GetComponent<Ship>().shipHealth;
            asteroidHealth -= 1;
            audioSources[0].PlayOneShot(laserImpactSound);

            if (asteroidHealth == 0)
            {
                AudioSource.PlayClipAtPoint(laserImpactSound,
                    new Vector2(0, 0));
                AudioSource.PlayClipAtPoint(explosionSound, new Vector2(0, 0));

                Destroy(gameObject);

                if (Random.Range(0.00f, 1.00f) < bulletsPowerUpChance && canAppear)
                {
                    Instantiate(BulletsPowerUp,
                        transform.position,
                        transform.rotation);
                    canAppear = false;
                    StartCoroutine(NoAppear());
                }

                if (
                    Random.Range(0.00f, 1.00f) < healthPowerUpChance &&
                    shipHealth < 10 &&
                    canAppear
                )
                {
                    Instantiate(HealthPowerUp,
                        transform.position,
                        transform.rotation);
                    canAppear = false;
                    StartCoroutine(NoAppear());
                }

                if (Random.Range(0.00f, 1.00f) < shieldPowerUpChance && canAppear && Ship.shield == false)
                {
                    Instantiate(ShieldPowerUp, transform.position, transform.rotation);
                    canAppear = false;
                    StartCoroutine(NoAppear());
                }
            }
        }

        if (col.gameObject.CompareTag("Ship") || col.gameObject.CompareTag("Shield")) Destroy(gameObject);
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