using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject ShipBullet;
    public float delayTime = 0.25f;
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

    private IEnumerator NoFire()
    {
        yield return new WaitForSeconds(delayTime);
        Instantiate(ShipBullet, transform.position, transform.rotation);
        audioData.Play(0);
        canShoot = true;
    }
}
