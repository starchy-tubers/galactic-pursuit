using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject EnemyBullet;
    public float delayTime = 2.0f;
    bool canShoot = true;

    private void Update()
    {
        if (!canShoot) return;
        canShoot = false;
        Instantiate(EnemyBullet, transform.position, transform.rotation);
        StartCoroutine(NoFire());
    }

    private IEnumerator NoFire()
    {
        yield return new WaitForSeconds(delayTime);
        canShoot = true;
    }
}
