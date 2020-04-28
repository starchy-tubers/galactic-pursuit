using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject EnemyBullet;

    bool canShoot = true;

    private void Update()
    {
        if (!canShoot) return;
        canShoot = false;
        StartCoroutine(NoFire());
    }

    private IEnumerator NoFire()
    {
        yield return new WaitForSeconds((float)RandomHandler.EnemyRandomShoot());
        Instantiate(EnemyBullet, transform.position, transform.rotation);
        canShoot = true;
    }
}
