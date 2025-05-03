using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Platform movement behavior
/// 
/// Decoupling this from any controls.
/// only responsible for updating position.
/// </summary>

public class PlatformMovement
{
    //load velocity from settings
    private const float _velocityMax = 20;

    public float updatePosition(int direction, float currentLocation)
    {
        if(direction != 0)
        {
            return currentLocation + (_velocityMax * direction) * Time.deltaTime;
        }
        return currentLocation;
    }
}
