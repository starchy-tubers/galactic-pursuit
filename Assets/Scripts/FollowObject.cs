using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;

    public float speed = 3000.0f;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = transform.position;
        position.y = Mathf.Lerp(transform.position.y, objectToFollow.transform.position.y, interpolation);
        position.x = Mathf.Lerp(transform.position.x, objectToFollow.transform.position.x, interpolation);

        transform.position = position;
    }
}