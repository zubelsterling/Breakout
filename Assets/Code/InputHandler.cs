using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : Singleton<InputHandler>
{

    public delegate void ArrowKeysTrigger(float d);
    public static ArrowKeysTrigger OnArrowKeyUpdate;

    //if left arrow or right arrow pressed
    private PlayerInput _input;
    private InputAction _action;

    public float direction = 0f;

    private void Awake()
    {
        //Debug.Log("asdasdasdad");

        //PlayerInput playerInput = new PlayerInput();

        //_input = Resources.Load<PlayerInput>("Assets/Code/Input/Move");
        //_action = _input.actions["Move"];
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1;
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }

        OnArrowKeyUpdate?.Invoke(direction);

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

