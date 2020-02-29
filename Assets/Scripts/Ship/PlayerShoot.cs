using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject ShipBullet;
    public float delayTime = 0.20f;
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
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BulletsPowerUp"))
        {
            delayTime = 0.1f;
        }
        if (col.gameObject.CompareTag("EnemyBullet") || col.gameObject.CompareTag("GreenEnemy") || col.gameObject.CompareTag("Asteroid"))
        {
            delayTime = 0.20f;
        }
    }

    private IEnumerator NoFire()
    {
        yield return new WaitForSeconds(delayTime);
        Instantiate(ShipBullet, new Vector3(transform.position.x, transform.position.y + 0.5f), transform.rotation);
        audioData.Play(0);
        canShoot = true;
    }
}
