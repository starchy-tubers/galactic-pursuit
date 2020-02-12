using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite notDamaged;
    public Sprite damaged;
    public float delayTime;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ShipBullet"))
        {
            spriteRenderer.sprite = damaged;
            // Animation.paused = true;
            StartCoroutine(SpriteDelay());
        }
    }

    private IEnumerator SpriteDelay()
    {
        yield return new WaitForSeconds(delayTime);
        spriteRenderer.sprite = notDamaged;
        // Animation.paused = false;
    }
}