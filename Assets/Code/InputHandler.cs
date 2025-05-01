using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    //singleton
    public static InputHandler instance;

    //if left arrow or right arrow pressed
    private PlayerInput _input;
    private InputAction _action;

    //public static event Input OnTriggered;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _input = GetComponent<PlayerInput>();
        _action = _input.actions["Move"];
    }

    private void Update()
    {
        Debug.Log(_action.ReadValue<float>());


    }

    public void OnParticleTrigger()
    {
        
    }
}

