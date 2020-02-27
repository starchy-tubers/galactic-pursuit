using UnityEngine;

// Script is broken.
public class EnemyHurt : MonoBehaviour
{
    public int enemyHealth = 5;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            enemyHealth -= 1;
            animator.SetTrigger("Damaged");

            if (enemyHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}