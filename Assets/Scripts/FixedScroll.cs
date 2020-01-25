using UnityEngine;

public class FixedScroll : MonoBehaviour
{
    public float theScrollSpeed = 0.08f;

    Transform mainCamera;

    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        mainCamera.position = new Vector3(mainCamera.position.x, mainCamera.position.y + theScrollSpeed, mainCamera.position.z);
    }
}