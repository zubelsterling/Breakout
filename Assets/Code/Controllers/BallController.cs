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

    private bool ballMove;

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

    public void enableMovement()
    {
        ballMove = true;
        //stop listening to enable
        InputHandler.spacePressed -= enableMovement;
    }

    private void handleBounds()
    {
        if (transform.position.x > Settings.instance.gameWidth/2 || transform.position.x < (Settings.instance.gameWidth/2) * -1)
        {
            movement.flipXDirection();
        }
        if (transform.position.y > Settings.instance.gameHeight/2)
        {
            movement.flipYDirection();
        }

        if (transform.position.y < (Settings.instance.gameHeight / 2) * -1)
        {
            BallEvents.ballOffScreen?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IBrickController>() != null)//check if collision is with a brick
        {
            if(collisionBehavior.simpleBounce(gameObject, collision.gameObject).y < 0)
            {
                movement.flipYDirection();
            }
            else{
                movement.flipXDirection();
            }
            
            collision.gameObject.GetComponent<IBrickController>().hit();
        }
        if(collision.gameObject.GetComponent<IPlatformController>() != null)
        {
            AudioEvents.platformBounceSound?.Invoke();
            movement.UpdateDirection(collisionBehavior.platformBounce(gameObject, collision.gameObject));
        }
    }
}
