using System.Collections;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public GameObject ShipLaser;
    public static float multiplier = 1.0f;
    public float delayTime = 0.50f / multiplier;
    public int minMultiplier = 1;
    public int maxMultiplier = 5;
    bool canShoot = true;
    public AudioSource audioData;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!canShoot) return;
        canShoot = false;
        StartCoroutine(NoFire());
        delayTime = 0.50f / multiplier;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BulletsPowerUp") && multiplier < maxMultiplier)
        {
            multiplier++;
        }

        if (col.gameObject.CompareTag("EnemyBullet") || col.gameObject.CompareTag("GreenEnemy") || col.gameObject.CompareTag("Asteroid"))
        {
            if (minMultiplier < multiplier)
            {
                multiplier--;
            }
        }
    }

    private IEnumerator NoFire()
    {
        yield return new WaitForSeconds(delayTime);
        Instantiate(ShipLaser, new Vector3(transform.position.x, transform.position.y + 0.5f), transform.rotation);
        audioData.Play(0);
        canShoot = true;
    }
}
