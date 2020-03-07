using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float velY;
    private const float velX = 0;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        // if (col.gameObject == gameObject)
        // {
        //     Physics.IgnoreCollision(GetComponent<Collider>(), GetComponent<Collider>());
        // }
        if (col.gameObject.CompareTag("Ship"))
        {
            Debug.Log("TASELAHJSDLAJSD");
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
