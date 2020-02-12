using UnityEngine;

public class FixedScroll : MonoBehaviour
{
    [SerializeField] private float theScrollSpeed = 0.0165f;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + theScrollSpeed, transform.position.z);
    }
}