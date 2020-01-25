using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject ShipBullet;
    public float delayTime = 0.2f;
    bool canShoot = true;
    public AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canShoot)
        {
            canShoot = false;
            Instantiate(ShipBullet, transform.position, transform.rotation);
            audioData.Play(0);
            StartCoroutine(NoFire());
        }
    }

    IEnumerator NoFire()
    {
        yield return new WaitForSeconds(delayTime);
        canShoot = true;
    }
}
