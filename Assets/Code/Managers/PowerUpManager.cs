using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//most likely not enough time for more powerups, but I'd rather show forward thinking
public enum EPowerUpType
{
    EXTRABALL
}

public class PowerUpManager : MonoBehaviour
{

    public GameObject extraBallPrefab;

    private void Start()
    {
        subscribeToEvents();
    }

    private void subscribeToEvents()
    {
        PowerUpEvents.powerUpSpawn += spawnPowerUp;
        PowerUpEvents.executePowerUp += powerUpCollected;
    }

    private void spawnPowerUp(EPowerUpType type, Vector2 location)
    {
        GameObject g = Instantiate(extraBallPrefab);
        g.transform.position = location;
    }

    private void powerUpCollected(EPowerUpType type)
    {
        //polymorphism can solve long if/else switch cases if this got too lengthy. 1 or 2 powerups are fine.
        if(type == EPowerUpType.EXTRABALL)
        {
            BallEvents.spawnExtraBall?.Invoke();
        }
    }
}
