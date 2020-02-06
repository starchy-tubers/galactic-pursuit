using UnityEngine;

public class Ship : MonoBehaviour
{
    FixedScroll fixedScroll;

    private void Start()
    {
        fixedScroll = (FixedScroll)FindObjectOfType(typeof(FixedScroll));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + fixedScroll.theScrollSpeed);
    }

}