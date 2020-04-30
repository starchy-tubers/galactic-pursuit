using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private const float movementSpeed = 1f;

    private Vector2 currentPos;

    public int enemyHealth = 5;

    private Vector2 position;

    private Direction shipDirection;

    private readonly float speed = 7f;

    private Vector3 startPosition;

    private Vector2 target;

    private void Start()
    {
        position = transform.position;
        target.y = transform.position.y - 6;
    }

    private void Update()
    {
        position.y =
            Mathf.MoveTowards(transform.position.y,
                target.y,
                Time.deltaTime * speed);
        transform.position = position;
    }

    private enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    // private void Update()
    // {
    //     switch (shipDirection)
    //     {
    //         case Direction.Left:
    //             {
    //                 transform.position = transform.position + new Vector3(2 * movementSpeed * Time.deltaTime, 0);
    //                 if (transform.position.x > startPosition.x + 1)
    //                 {
    //                     shipDirection = Direction.Right;
    //                 }

    //                 break;
    //             }
    //         case Direction.Right:
    //             {
    //                 transform.position = transform.position - new Vector3(2 * movementSpeed * Time.deltaTime, 0);
    //                 if (transform.position.x < startPosition.x - 1)
    //                 {
    //                     shipDirection = Direction.Left;
    //                 }

    //                 break;
    //             }
    //         case Direction.Up:
    //             break;
    //         case Direction.Down:
    //             break;
    //         default:
    //             throw new ArgumentOutOfRangeException();
    //     }
    // }
}