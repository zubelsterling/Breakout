using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformController : ScriptableObject
{
    public PlatformController(IPlatformMovement platform)
    {

    }

    public void onMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ToString());
    }
}

