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

    private const float _velocityMax = 20;
    private float direction = 0;

    private Vector3 _newLoc = new Vector3();

    void Start()
    {
        _newLoc.y = this.transform.position.y;
        _newLoc.x = 0;

        InputHandler.OnArrowKeyUpdate += setDirection;
    }

    public void setDirection(float d)
    {
        direction = d;
    }

    void Update()
    {
        if(direction != 0)
        {
            _newLoc.x = this.transform.position.x + (_velocityMax * direction) * Time.deltaTime;
            this.transform.position = _newLoc;
        }
    }
}
