using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Platform movement behavior
/// 
/// Decoupling this from any controls or drivers.
/// This class will just listen for when to change velocity
/// but will update position every frame as long as veloctiy is > 0
/// </summary>

public class PlatformMovement : MonoBehaviour, IPlatformMovement
{

    private const float _velocityMax = 10;
    private int direction = 0;

    private Vector3 _newLoc = new Vector3();

    public void moveLeft()
    {
        direction = 1;
    }

    public void moveRight()
    {
        direction = -1;
    }

    public void stop()
    {
        direction = 0;
    }

    void Start()
    {
        _newLoc.y = this.transform.position.y;
        _newLoc.x = 0;
    }

    void Update()
    {
        if(direction != 0)
        {
            _newLoc.x = this.transform.position.x + (_velocityMax * direction);
            this.transform.position = _newLoc;
        }
    }
}
