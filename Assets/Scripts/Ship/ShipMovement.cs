using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    bool moveLeft = false;
    bool moveRight = false;
    bool locked = false;
    bool canDoAction = true;
    Vector2 position;
    Vector2 target;
    float speed = 15f;
    Camera camera;
    float cameraWidth;
    float movementDistance;
    float numberOfColumns = 5;

    void Start()
    {
        camera = Camera.main;
        cameraWidth = camera.aspect * camera.orthographicSize * 2;
        movementDistance = cameraWidth / numberOfColumns;
        position = transform.position;
        target.y = -5.5f;
    }

    void Update()
    {
        position.y = Mathf.MoveTowards(transform.position.y, target.y, Time.deltaTime * 7f);
        transform.position = position;



        if (Input.GetKeyDown("left") && canDoAction)
        {
            moveLeft = true;
        }
        if (Input.GetKeyDown("right") && canDoAction)
        {
            moveRight = true;
        }

        if (Input.touchCount > 0)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    if (Input.GetTouch(0).position.x < Screen.width / 2)
                    {
                        moveLeft = true;
                    }
                    else if (Input.GetTouch(0).position.x > Screen.width / 2)
                    {
                        moveRight = true;
                    }
                    break;
            }
        }

        if (moveLeft)
        {
            canDoAction = false;

            if (!locked && transform.position.x > -3) //TODO: Make "3" a calculated value?
            {
                target.x = transform.position.x - movementDistance;
                locked = true;
            }

            position.x = Mathf.MoveTowards(transform.position.x, target.x, Time.deltaTime * speed);
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
            if (!locked && transform.position.x < 3)
            {
                target.x = transform.position.x + movementDistance;
                locked = true;
            }

            position.x = Mathf.MoveTowards(transform.position.x, target.x, Time.deltaTime * speed);
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
