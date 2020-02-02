using UnityEngine;

public class Ship : MonoBehaviour
{
    FixedScroll fixedScroll;

    private void Start()
    {
        fixedScroll = (FixedScroll)FindObjectOfType(typeof(FixedScroll));
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + fixedScroll.theScrollSpeed);
    }

}