using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls movement and collection components
/// 
/// 
/// </summary>

public class PowerUpController : MonoBehaviour
{
    public EPowerUpType powerUpType = EPowerUpType.EXTRABALL;//default to extra ball
    float fallVelocity = 5f;
    Vector3 newPosition;

    private void Start()
    {
        newPosition = transform.position;
    }

    void Update()
    {
        newPosition.y -= fallVelocity * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IPlatformController>() != null)
        {
            Debug.Log("platform");
            PowerUpEvents.executePowerUp?.Invoke(powerUpType);
            gameObject.SetActive(false);
        }
    }
}