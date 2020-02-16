using UnityEngine;

public class FixedScroll : MonoBehaviour
{
    private float theScrollSpeed = 0.1f;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + theScrollSpeed, transform.position.z);
    }
}