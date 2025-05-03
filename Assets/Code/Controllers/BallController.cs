using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is intended to control a ball and its collisions / math / movement
/// </summary>

public class BallController : MonoBehaviour
{

    private BallMovement movement; //swap to interface?
    private Vector2 currentLocation;

    private bool ballMove;//hook this up later

    delegate void ChangeDirection(Vector2 direction);
    ChangeDirection changeDirection;

    private void Awake()
    {
        movement = new BallMovement();
        currentLocation = new Vector2(transform.position.x, transform.position.y);
        movement.UpdateDirection(new Vector2(0,1));
    }

    private void Update()
    {
        currentLocation = movement.updateLocation(currentLocation);
        transform.position = new Vector3(currentLocation.x, currentLocation.y, 0);
    }
}
