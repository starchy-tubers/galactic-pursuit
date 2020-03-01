using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidAppear : MonoBehaviour
{
    bool canAppear = true;
    float RandomNum;
    static float[] xCoordinates = new float[] { -3.0f, -1.5f, 0.0f, 1.5f, 3.0f, };
    public GameObject Asteroid;
    private void Update()
    {
        RandomNum = xCoordinates[Random.Range(0, 4)];
        if (!canAppear) return;
        canAppear = false;
        StartCoroutine(NoAppear());
    }

    private IEnumerator NoAppear()
    {
        yield return new WaitForSeconds((float)RandomHandler.AsteroidRandomAppear());
        Instantiate(Asteroid, new Vector2(RandomNum, 7), transform.rotation);
        canAppear = true;
    }
}