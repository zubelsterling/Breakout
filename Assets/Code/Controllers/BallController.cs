using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is intended to control a ball and its collisions / math / movement
/// </summary>

public class BallController : MonoBehaviour
{

    private BallMovement movement; //swap to interface?
    private BallCollisionBehavior collisionBehavior;
    private Vector2 currentLocation;

    private bool ballMove;//hook this up later

    delegate void ChangeDirection(Vector2 direction);
    ChangeDirection changeDirection;

    private void OnEnable()
    {
        movement = new BallMovement();
        collisionBehavior = new BallCollisionBehavior();
        currentLocation = new Vector2(transform.position.x, transform.position.y);
        movement.UpdateDirection(new Vector2(1,1));
        InputHandler.spacePressed += enableMovement;
        ballMove = false;
    }

    private void OnDisable()
    {
        //just in case.
        InputHandler.spacePressed -= enableMovement;
    }

    private void Update()
    {
        if (!ballMove)
        {
            return;
        }

        currentLocation = movement.updateLocation(currentLocation);
        transform.position = new Vector3(currentLocation.x, currentLocation.y, 0);
        handleBounds();

    }

    private void enableMovement()
    {
        ballMove = true;
        //stop listening to enable
        InputHandler.spacePressed -= enableMovement;
    }

    private void handleBounds()
    {
        if (transform.position.x > 10 || transform.position.x < -10)
        {
            movement.flipXDirection();
        }
        if (transform.position.y > 5)
        {
            movement.flipYDirection();
        }

        if (transform.position.y < -6)
        {
            BallManager.ballOffScreen?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IBrickController>() != null)//check if collision is with a brick
        {
            movement.ReflectDirection(collisionBehavior.simpleBounce(gameObject, collision.gameObject));
            collision.gameObject.GetComponent<IBrickController>().hit();
        }
        if(collision.gameObject.GetComponent<IPlatformController>() != null)
        {
            Debug.Log("platformhit");
            movement.UpdateDirection(collisionBehavior.platformBounce(gameObject, collision.gameObject));
        }
    }
}
