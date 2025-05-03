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
        movement.UpdateDirection(randomStartDirection());
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

        movement.UpdateDirection(randomStartDirection());
    }

    private void handleBounds()
    {
        if (transform.position.x > Settings.instance.gameWidth/2 || transform.position.x < (Settings.instance.gameWidth/2) * -1)
        {
            movement.flipXDirection();
        }
        if (transform.position.y > Settings.instance.gameHeight/2 && movement.getDirection().y > 0)
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
        //brick Collision
        if(collision.gameObject.GetComponent<IBrickController>() != null)
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
        //platform Collision
        if(collision.gameObject.GetComponent<IPlatformController>() != null)
        {
            AudioEvents.platformBounceSound?.Invoke();
            movement.UpdateDirection(collisionBehavior.platformBounce(gameObject, collision.gameObject));
        }
    }

    private Vector2 randomStartDirection()
    {
        //random angle
        float x = Random.Range(100, 150) / 100;
        float y = 2 - Mathf.Abs(x);

        //random direction
        x *= Random.Range(0, 1) == 1 ? 1 : -1;

        return new Vector2(x, y);
    }
}
