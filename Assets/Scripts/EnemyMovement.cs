using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float movementSpeed = 1f;
    FixedScroll fixedScroll;

    private enum Direction { Left, Right, Up, Down };
    private Direction shipDirection;
    Vector3 startPosition;
    public int enemyHealth = 5;

    void Start()
    {
        fixedScroll = (FixedScroll)FindObjectOfType(typeof(FixedScroll));
        shipDirection = Direction.Left;
        startPosition = transform.position;
    }

    void OnCollisionEnter2D()
    {
        enemyHealth -= 1;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + fixedScroll.theScrollSpeed, 1);
        if (shipDirection == Direction.Left)
        {
            transform.position = transform.position + new Vector3(2 * movementSpeed * Time.deltaTime, 0);
            if (transform.position.x > startPosition.x + 1)
            {
                shipDirection = Direction.Right;   
            }
        }
        else if (shipDirection == Direction.Right)
        {
            transform.position = transform.position - new Vector3(2 * movementSpeed * Time.deltaTime, 0);
            if (transform.position.x < startPosition.x - 1)
            {
                shipDirection = Direction.Left;
            }
        }
    }
}
