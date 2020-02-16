using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxer : MonoBehaviour
{
    public float ParallaxFactor = 0;

    Transform theCamera;
    Vector3 theStartPosition;

    private void Start()
    {
        theCamera = Camera.main.transform;
        theStartPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the position of the object
        var newPos = theCamera.position * ParallaxFactor; 
        // Force Z-axis to zero, since we're in 2D
        newPos.z = 0; 
        newPos.x += theStartPosition.x;
        newPos.y += theStartPosition.y;
        transform.position = newPos;
    }
}
