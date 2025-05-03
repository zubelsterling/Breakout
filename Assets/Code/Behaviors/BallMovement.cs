using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement
{

    private float _xVelBase = 5f;
    private float _yVelBase = 5f;

    private float _speedIncrease = 0;

    private Vector2 _direction;

    public void addSpeed(float speed) => _speedIncrease += speed;
    public void UpdateDirection(Vector2 direction) => _direction = direction;   //more control over angles

    //useful if ball is hitting a wall.
    public void flipXDirection() => _direction.x *= -1;
    public void flipYDirection() => _direction.y *= -1;

    public Vector2 updateLocation(Vector2 currentLoc)
    {
        Vector2 newLoc = currentLoc;

        newLoc.x = currentLoc.x + ((_speedIncrease + _xVelBase) * Time.deltaTime)*_direction.x;
        newLoc.y = currentLoc.y + ((_speedIncrease + _yVelBase) * Time.deltaTime)*_direction.y;

        return newLoc;
    }
}
