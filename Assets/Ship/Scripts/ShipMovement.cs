using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public static bool movementDisabled = false;

    private bool canDoAction = true;

    private int columnPosition = 2;

    private bool locked;
    private bool moveLeft;

    private float movementDistance;

    private bool moveRight;

    private Vector2 position;

    private readonly float speed = 15f;

    private Vector2 target;

    private void Start()
    {
        movementDistance = Screen.width / (Screen.width / 1.5f);
        position = transform.position;
        target.y = -5.5f;
    }

    private void Update()
    {
        position.y =
            Mathf.MoveTowards(transform.position.y,
                target.y,
                Time.deltaTime * 7f);
        transform.position = position;

        if (Input.GetKeyDown("left") && canDoAction && PauseMenu.gameIsPaused == false && !movementDisabled)
            moveLeft = true;
        if (Input.GetKeyDown("right") && canDoAction && PauseMenu.gameIsPaused == false && !movementDisabled)
            moveRight = true;

        if (Input.touchCount > 0 && !movementDisabled)
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    if (Input.GetTouch(0).position.x < Screen.width / 2 &&
                        Input.GetTouch(0).position.y < Screen.height / 2 && PauseMenu.gameIsPaused == false)
                        moveLeft = true;
                    else if (Input.GetTouch(0).position.x > Screen.width / 2 &&
                             Input.GetTouch(0).position.y < Screen.height / 2 &&
                             PauseMenu.gameIsPaused == false) moveRight = true;
                    break;
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