using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
    public int shipHealth = 3;
    public Sprite[] spriteList;
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
                    spriteRenderer.sprite = spriteList[0];
                    break;
                case 2:
                    spriteRenderer.sprite = spriteList[1];
                    break;
                case 1:
                    spriteRenderer.sprite = spriteList[2];
                    break;
                default:
                    spriteRenderer.sprite = spriteList[3];
                    break;
            }

            if (shipHealth == 0) 
            {
                Destroy(gameObject);
            }
        }
    }
}