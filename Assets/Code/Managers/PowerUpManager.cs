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
    [Range (1, 20)]
    public int poolSize;

    private IPowerUpObjPool _powerUpPool;

    private void Start()
    {
        _powerUpPool = new PowerUpObjPool();
        _powerUpPool.fillPool(poolSize, extraBallPrefab);
        subscribeToEvents();
    }

    private void subscribeToEvents()
    {
        PowerUpEvents.powerUpSpawn += spawnPowerUp;
        PowerUpEvents.executePowerUp += powerUpCollected;
        PowerUpEvents.powerUpRecycle += _powerUpPool.returnToPool;
    }

    private void spawnPowerUp(EPowerUpType type, Vector2 location)
    {
        GameObject g = _powerUpPool.pop();
        if (g != null)
        {
            g.transform.position = location;
            g.SetActive(true);
        }
    }

    private void powerUpCollected(EPowerUpType type)
    {
        //delegate here if I had more than 1 powerup
        if(type == EPowerUpType.EXTRABALL)
        {
            BallEvents.spawnExtraBall?.Invoke();
        }
    }
}
