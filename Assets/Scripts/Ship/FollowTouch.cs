using UnityEngine;

public class FollowTouch : MonoBehaviour
{
    private void Update()
    {
        // If left-mouse-button is being held OR there is at least one touch
        if (!Input.GetMouseButton(0) && Input.touchCount <= 0) {
            return;
        }
        
        // Get mouse position in screen space
        // (If touch, gets average of all touches)
        var screenPos = Input.mousePosition;

        // Set a distance from the camera
        screenPos.z = 200.0f;

        // Convert mouse position to world space
        var worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        // Get current position of this GameObject
        var newPos = transform.position;

        // Set x position to mouse world-space x position
        newPos.x = worldPos.x;
        newPos.y = worldPos.y;

        // Apply new position
        transform.position = newPos;
    }    
}
