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

    private void OnEnable()
    {
        newPosition = transform.position;
    }

    void Update()
    {
        newPosition.y -= fallVelocity * Time.deltaTime;
        transform.position = newPosition;
        if(transform.position.y < (Settings.instance.gameHeight / 2) * -1)
        {
            PowerUpEvents.powerUpRecycle(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IPlatformController>() != null)
        {
            AudioEvents.powerUpCollectSound?.Invoke();
            PowerUpEvents.executePowerUp?.Invoke(powerUpType);
            PowerUpEvents.powerUpRecycle?.Invoke(gameObject);
        }
    }
}