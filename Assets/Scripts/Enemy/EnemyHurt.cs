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
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = notDamaged;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            ChangeSprite();
            StartCoroutine(SpriteDelay());
        }
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = damaged;
    }
    private IEnumerator SpriteDelay()
    {
        yield return new WaitForSeconds(delayTime);
        ChangeSprite2();
    }
    void ChangeSprite2()
    {
        spriteRenderer.sprite = notDamaged;
    }
}