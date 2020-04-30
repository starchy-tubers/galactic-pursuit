using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private bool canShoot = true;
    public GameObject EnemyBullet;

    private void Update()
    {
        if (!canShoot) return;
        canShoot = false;
        StartCoroutine(NoFire());
    }

    private IEnumerator NoFire()
    {
        yield return new WaitForSeconds((float) RandomHandler.EnemyRandomShoot());
        Instantiate(EnemyBullet, transform.position, transform.rotation);
        canShoot = true;
    }
}