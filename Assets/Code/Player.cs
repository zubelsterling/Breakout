using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlatformController platformController;
    public GameObject platform;
    public IPlatformMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = platform.GetComponent<IPlatformMovement>();
        platformController = new PlatformController(movement);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
