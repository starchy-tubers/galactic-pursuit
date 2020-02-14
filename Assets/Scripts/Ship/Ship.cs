using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
    public int shipHealth = 3;
    public float delayTime = 0.01f;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            shipHealth -= 1;
            if (shipHealth == 0) 
            {
             StartCoroutine(destroy());
            }
        }
    }
    private IEnumerator destroy()
        {
            yield return new WaitForSeconds(delayTime);
            Destroy(gameObject);
        }
}