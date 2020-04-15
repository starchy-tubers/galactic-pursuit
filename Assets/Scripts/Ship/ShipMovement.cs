using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    bool moveLeft = false;

    bool moveRight = false;

    bool locked = false;

    bool canDoAction = true;

    private Vector2 position;

    private Vector2 target;

    private float speed = 15f;

    private float movementDistance;

    private int columnPosition = 2;

    void Start()
    {
        movementDistance = (float)Screen.width / (((float)Screen.width / 1.5f));
        position = transform.position;
        target.y = -5.5f;
    }

    void Update()
    {
        position.y =
            Mathf.MoveTowards(transform.position.y,
            target.y,
            Time.deltaTime * 7f);
        transform.position = position;

        if (Input.GetKeyDown("left") && canDoAction && PauseMenu.GameisPaused == false)
        {
            moveLeft = true;
        }
        if (Input.GetKeyDown("right") && canDoAction && PauseMenu.GameisPaused == false)
        {
            moveRight = true;
        }

        if (Input.touchCount > 0)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    if (Input.GetTouch(0).position.x < Screen.width / 2 && Input.GetTouch(0).position.y < Screen.height / 2 && PauseMenu.GameisPaused == false)
                    {
                        moveLeft = true;
                    }
                    else if (Input.GetTouch(0).position.x > Screen.width / 2 && Input.GetTouch(0).position.y < Screen.height / 2 && PauseMenu.GameisPaused == false)
                    {
                        moveRight = true;
                    }
                    break;
            }
        }

        if (moveLeft)
        {
            canDoAction = false;

            if (
                !locked && columnPosition != 0
            )
            {
                target.x = transform.position.x - movementDistance;
                locked = true;
                columnPosition--;
            }
            position.x =
                Mathf.MoveTowards(transform.position.x,
                target.x,
                Time.deltaTime * speed);
            transform.position = position;
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
            if (!locked && columnPosition != 4)
            {
                target.x = transform.position.x + movementDistance;
                locked = true;
                columnPosition++;
            }

            position.x = Mathf.MoveTowards(transform.position.x,
                target.x,
                Time.deltaTime * speed);
            transform.position = position;
            if (transform.position.x == target.x)
            {
                moveRight = false;
                locked = false;
                canDoAction = true;
            }
        }
    }
}