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
        if (Input.GetKey("left") && canDoAction)
        {
            moveLeft = true;
        }
        if (Input.GetKey("right") && canDoAction)
        {
            moveRight = true;
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                moveLeft = true;
            }
            else if (touch.position.x > Screen.width / 2)
            {
                moveRight = true;
            }
        }

        if (moveLeft)
        {
            canDoAction = false;
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
                canDoAction = true;
            }
        }

        if (moveRight)
        {
            canDoAction = false;
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
                canDoAction = true;
            }
        }
    }
}
