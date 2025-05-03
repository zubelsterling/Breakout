using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : Singleton<InputHandler>
{

    public delegate void ArrowKeysTrigger(int d);
    public static ArrowKeysTrigger OnArrowKeyUpdate;

    public delegate void SpacePressed();
    public static SpacePressed spacePressed;

    //if left arrow or right arrow pressed
    private PlayerInput _input;
    private InputAction _action;

    public float direction = 0;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnArrowKeyUpdate?.Invoke(-1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            OnArrowKeyUpdate?.Invoke(1);
        }
        else
        {
            OnArrowKeyUpdate?.Invoke(0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            spacePressed?.Invoke();
        }



        //fix this later. Lets just get this working
        //if (_action.WasPressedThisFrame())
        //{
        //    Debug.Log("Is this working");
        //    OnArrowKeysTrigger?.Invoke();
        //}
        //Debug.Log(_action.ReadValue<float>());

        //direction = _action.ReadValue<float>();
    }
}

