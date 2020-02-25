using UnityEngine;

public class Ship : MonoBehaviour
{
    public int shipHealth = 3;
    public Sprite[] spriteList;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GameObject.FindWithTag("HealthBar").GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EnemyBullet") || col.gameObject.CompareTag("GreenEnemy") || col.gameObject.CompareTag("Asteroid"))
        {
            shipHealth -= 1;

            switch (shipHealth)
            {
                case 3:
                    spriteRenderer.sprite = spriteList[3];
                    break;
                case 2:
                    spriteRenderer.sprite = spriteList[2];
                    break;
                case 1:
                    spriteRenderer.sprite = spriteList[1];
                    break;
                default:
                    spriteRenderer.sprite = spriteList[0];
                    break;
            }


            if (shipHealth == 0)
            {

                Destroy(gameObject);
            }
        }
    }


}