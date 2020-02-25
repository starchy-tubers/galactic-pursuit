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
    Camera camera;
    float cameraWidth;
    float movementDistance;
    float numberOfColumns = 5;

    void Start()
    {
        camera = Camera.main;
        cameraWidth = camera.aspect * camera.orthographicSize * 2;
        movementDistance = cameraWidth / numberOfColumns;
        pos = transform.position;
    }

    void Update()
    {
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
            if (!locked && transform.position.x < 3)
            {
                target.x = transform.position.x + movementDistance;
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
