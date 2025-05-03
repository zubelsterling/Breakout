using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private InputHandler _inputHandler;

    private PlatformController platformController;
    public GameObject platform;
    private IPlatformMovement movement;
    private InputHandler _inputHandler;

    delegate void moveLeft();
    delegate void moveRight();

    moveLeft movementLeft;
    moveRight movementRight;

    void Start()
    {
        platformController = platform.GetComponent<PlatformController>();
        _inputHandler = InputHandler.instance;
    }


}
