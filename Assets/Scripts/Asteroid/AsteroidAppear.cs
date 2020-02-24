using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidAppear : MonoBehaviour
{
    bool canAppear = true;
    float RandomNum;
    public GameObject Asteroid;
    private void Update()
    {
        RandomNum = Random.Range(-2.4f, 2.4f);
        if (!canAppear) return;
        canAppear = false;
        StartCoroutine(NoAppear());
    }

    private IEnumerator NoAppear()
    {
        yield return new WaitForSeconds((float)RandomHandler.AsteroidRandomAppear());
        Instantiate(Asteroid, new Vector2(RandomNum, 5), transform.rotation);
        canAppear = true;
    }
}