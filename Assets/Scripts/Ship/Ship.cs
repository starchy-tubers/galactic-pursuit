using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
    public int shipHealth = 3;
    public Sprite healthBar3;
    public Sprite healthBar2;
    public Sprite healthBar1;
    public Sprite healthBar0;
    private SpriteRenderer spriteRenderer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            spriteRenderer = GameObject.FindWithTag("HealthBar").GetComponent<SpriteRenderer>();
            shipHealth -= 1;

            switch (shipHealth)
            {
                case 3:
                    spriteRenderer.sprite = healthBar3;
                    break;
                case 2:
                    spriteRenderer.sprite = healthBar2;
                    break;
                case 1:
                    spriteRenderer.sprite = healthBar1;
                    break;
                default:
                    spriteRenderer.sprite = healthBar0;
                    break;
            }

            if (shipHealth == 0) 
            {
                Destroy(gameObject);
            }
        }
    }
}