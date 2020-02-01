using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTouch : MonoBehaviour

{
    // Vector3 savePos = new Vector3();

    void Update()
    {
        // if left-mouse-button is being held OR there is at least one touch
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            // get mouse position in screen space
            // (if touch, gets average of all touches)
            var screenPos = Input.mousePosition;
            // set a distance from the camera
            screenPos.z = 200.0f;
            // convert mouse position to world space
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

            // get current position of this GameObject
            Vector3 newPos = transform.position;
            // set x position to mouse world-space x position
            newPos.x = worldPos.x;
            newPos.y = worldPos.y;
            // apply new position
            transform.position = newPos;
        }

    }
}

