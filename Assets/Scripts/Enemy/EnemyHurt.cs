using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script is broken.
public class EnemyHurt : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite notDamaged;
    public Sprite damaged;
    public float delayTime;
    public Color m_NewColor;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ShipBullet"))
        {
            StartCoroutine(SpriteDelay());
        }
    }

    private IEnumerator SpriteDelay()
    {
        yield return new WaitForSeconds(delayTime);
    }
}