using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformController : MonoBehaviour, IPlatformController
{
    //subscribe to input
    private int _direction = 0;
    private PlatformMovement _movement;

    private void Awake()
    {
        _movement = new PlatformMovement();
        InputHandler.OnArrowKeyUpdate += updateDirection; 
    }

    private void Update()
    {
        if (_direction != 0 && checkBounds())
        {
            transform.position = new Vector3(_movement.updatePosition(_direction, transform.position.x), transform.position.y, 0);
        }
    }

    private void updateDirection(int direction)
    {
        _direction = direction;
    }
    private bool checkBounds()
    {
        if (_direction < 0 && transform.position.x < (Settings.instance.gameWidth * -1) / 2)
            return false;
        if (_direction > 0 && transform.position.x > Settings.instance.gameWidth / 2)
            return false;
        return true;
    }
}

