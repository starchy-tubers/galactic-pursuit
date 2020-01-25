using UnityEngine;

public class Ship : MonoBehaviour
{
    FixedScroll fixedScroll;

    void Start()
    {
        fixedScroll = (FixedScroll)FindObjectOfType(typeof(FixedScroll));
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + fixedScroll.theScrollSpeed);
    }

}