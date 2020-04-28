using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    [SerializeField] public int shipHealth = 10;
    [SerializeField] Sprite[] healthBarSpriteArray;
    private SpriteRenderer spriteRenderer;
    bool canDamage = true;
    public static bool shield = false;
    AudioSource[] audioSources;
    AudioClip shipLaser;
    AudioClip shipImpact;
    AudioClip shipDeath;
    Animator animator;

    private void Start()
    {
        spriteRenderer = GameObject.FindWithTag("HealthBar").GetComponent<SpriteRenderer>();
        audioSources = GetComponents<AudioSource>();
        shipLaser = audioSources[0].clip;
        shipImpact = audioSources[1].clip;
        shipDeath = audioSources[2].clip;
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // TODO: Need to make a list of things that can damage the ship and check if the gameObject exists in that list
        // This if statement is unsustainable as more hostile objects are added
        if (
            col.gameObject.CompareTag("EnemyProjectile") ||
            col.gameObject.CompareTag("BasicEnemy") ||
            col.gameObject.CompareTag("Asteroid")
        )
        {
            if (shield == false)
            {
                shipHealth -= 1;
                audioSources[1].PlayOneShot(shipImpact);
                animator.SetTrigger("Damaged");
            }
        }

        if (col.gameObject.CompareTag("HealthPack") && shipHealth < 10)
        {
            shipHealth++;
        }

        switch (shipHealth)
        {
            case 10:
                spriteRenderer.sprite = healthBarSpriteArray[10];
                break;
            case 9:
                spriteRenderer.sprite = healthBarSpriteArray[9];
                break;
            case 8:
                spriteRenderer.sprite = healthBarSpriteArray[8];
                break;
            case 7:
                spriteRenderer.sprite = healthBarSpriteArray[7];
                break;
            case 6:
                spriteRenderer.sprite = healthBarSpriteArray[6];
                break;
            case 5:
                spriteRenderer.sprite = healthBarSpriteArray[5];
                break;
            case 4:
                spriteRenderer.sprite = healthBarSpriteArray[4];
                break;
            case 3:
                spriteRenderer.sprite = healthBarSpriteArray[3];
                break;
            case 2:
                spriteRenderer.sprite = healthBarSpriteArray[2];
                break;
            case 1:
                spriteRenderer.sprite = healthBarSpriteArray[1];
                break;
            case 0:
                shipHealth = -1;
                spriteRenderer.sprite = healthBarSpriteArray[0];
                gameObject.GetComponent<Renderer>().enabled = false;
                ShipShoot.shootDisabled = true;
                AudioSource.PlayClipAtPoint(shipDeath, new Vector2(0, 0));
                StartCoroutine(GameOver());
                break;
            default:
                break;
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync("Game Over");
    }

}
