using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    private float _xVelBase = 5f;
    private float _yVelBase = 5f;

    private float _speedIncrease = 0;

    //vector of either -1 or 1 but I suppose could be decimals for precise angles
    private Vector2 _direction;

    private float newPosX = 0;
    private float newPosY = 0;

    public bool shouldUpdate = false;

    private void Awake()
    {
        //0,1 because in the base game, when you start the ball goes vertical
        _direction = new Vector2(0, 1);
    }

    void Update()
    {
        
        if (shouldUpdate)
        {

            newPosX = transform.position.x + ((_speedIncrease + _xVelBase) * Time.deltaTime)*_direction.x;
            newPosY = transform.position.y + ((_speedIncrease + _yVelBase) * Time.deltaTime)*_direction.y;

            this.transform.position = new Vector3(newPosX, newPosY, this.transform.position.z);
        }
        
    }

    public void addSpeed(float speed)
    {
        _speedIncrease += speed;
    }

    public void updateDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void shouldMove(bool shouldMove)
    {
        shouldUpdate = shouldMove;
    }
}
