using System.Collections;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public static float multiplier = 1.0f;

    public static float multiplierTimer = 4.0f;

    public static int minMultiplier = 1;

    public static int maxMultiplier = 5;

    public static bool canShoot = true;
    public static bool shootDisabled = false;
    public AudioSource audioData;
    public GameObject ShipLaser;

    public float shootDelayTime = 0.50f / multiplier;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    private void Update()
    {
        multiplierTimer -= Time.deltaTime;
        if (multiplierTimer < 0 && minMultiplier < multiplier)
        {
            multiplier--;
            multiplierTimer = 4.0f;
        }

        shootDelayTime = 0.50f / multiplier;
        if (!canShoot) return;
        canShoot = false;
        StartCoroutine(NoFire());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BulletsPowerUp"))
        {
            multiplierTimer = 4.0f;
            if (multiplier < maxMultiplier) multiplier++;
        }

        if (col.gameObject.CompareTag("EnemyProjectile") || col.gameObject.CompareTag("BasicEnemy") ||
            col.gameObject.CompareTag("Asteroid"))
        {
            multiplierTimer = 4.0f;
            if (minMultiplier < multiplier) multiplier--;
        }
    }

    private IEnumerator NoFire()
    {
        yield return new WaitForSeconds(shootDelayTime);

        if (!shootDisabled)
            Instantiate(ShipLaser, new Vector3(transform.position.x, transform.position.y + 0.5f), transform.rotation);
        audioData.Play(0);
        canShoot = true;
    }
}