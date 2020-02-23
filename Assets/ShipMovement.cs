using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    bool moveLeft = false;
    bool moveRight = false;
    bool locked = false;
    bool canDoAction = true;
    Vector2 pos;
    Vector2 target;
    float speed = 15f;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            moveLeft = true;
        }
        if (Input.GetKeyDown("right"))
        {
            moveRight = true;
        }

        if (moveLeft)
        {
            if (!locked && transform.position.x != -3)
            {
                target.x = transform.position.x - 2;
                locked = true;
            }

            pos.x = Mathf.MoveTowards(transform.position.x, target.x, Time.deltaTime * speed);
            transform.position = pos;
            if (transform.position.x == target.x)
            {
                moveLeft = false;
                locked = false;
            }
        }

        if (moveRight)
        {
            if (!locked && transform.position.x != 3)
            {
                target.x = transform.position.x + 2;
                locked = true;
            }

            pos.x = Mathf.MoveTowards(transform.position.x, target.x, Time.deltaTime * speed);
            transform.position = pos;
            if (transform.position.x == target.x)
            {
                moveRight = false;
                locked = false;
            }
        }
    }
}
