using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformController: MonoBehaviour
{
    private IPlatformMovement mover;

    private void Awake()
    {
        mover = GetComponent<IPlatformMovement>();
    }
    
    public void setDirection(float d)
    {
        mover.setDirection(d);
    }

}

