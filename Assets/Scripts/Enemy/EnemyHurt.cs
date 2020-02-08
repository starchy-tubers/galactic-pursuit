using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public float delayTime;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprite1;
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
        spriteRenderer.sprite = sprite2;
    }
    private IEnumerator SpriteDelay()
    {
        yield return new WaitForSeconds(delayTime);
        ChangeSprite2();
    }
    void ChangeSprite2()
    {
        spriteRenderer.sprite = sprite1;
    }
}