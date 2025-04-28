using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformController: ScriptableObject
{
    private IPlatformMovement mover;

    public PlatformController(IPlatformMovement platform)
    {
        mover = platform;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("button was pressed");

        if(context.ReadValue<float>() < 0)
        {
            //negative
            mover.moveLeft();
        }else if(context.ReadValue<float>() > 0)
        {
            //positive
            mover.moveRight();
        }
        else
        {
            //no keys
            //this might not work unless it fires signals for keyup 
            mover.stop();
        }
    }

    private void OnActionTriggered(InputAction.CallbackContext context)
    {
        Debug.Log("action triggered");
        if (context.action.name == "Move")
        {
            Debug.Log("sasdf");
        }
    }
}

