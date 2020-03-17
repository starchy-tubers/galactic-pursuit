using System.Collections;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public GameObject ShipLaser;

    public static float multiplier = 1.0f;

    public float shootDelayTime = 0.50f / multiplier;

    public static int minMultiplier = 1;

    public static int maxMultiplier = 5;

    bool canShoot = true;

    public AudioSource audioData;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    private void Update()
    {
        shootDelayTime = 0.50f / multiplier;
        if (!canShoot) return;
        canShoot = false;
        StartCoroutine(NoFire());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (
            col.gameObject.CompareTag("BulletsPowerUp") &&
            multiplier < maxMultiplier
        )
        {
            multiplier++;
        }

        if (
            col.gameObject.CompareTag("EnemyBullet") ||
            col.gameObject.CompareTag("BasicEnemy") ||
            col.gameObject.CompareTag("Asteroid")
        )
        {
            if (minMultiplier < multiplier)
            {
                multiplier--;
            }
        }
    }

    private IEnumerator NoFire()
    {
        yield return new WaitForSeconds(shootDelayTime);
        Instantiate(ShipLaser,
        new Vector3(transform.position.x, transform.position.y + 0.5f),
        transform.rotation);
        audioData.Play(0);
        canShoot = true;
    }
}
