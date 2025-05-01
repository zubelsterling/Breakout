using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private InputHandler _inputHandler;

    public PlatformController platformController;
    public GameObject platform;
    public IPlatformMovement movement;
    private InputHandler _inputHandler;

    delegate void moveLeft();
    delegate void moveRight();

    moveLeft movementLeft;
    moveRight movementRight;

    // Start is called before the first frame update
    void Start()
    {
        movement = platform.GetComponent<IPlatformMovement>();
        platformController = new PlatformController(movement);
        _inputHandler = InputHandler.instance;

        movementLeft = movement.moveLeft;
        movementRight = movement.moveRight;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
