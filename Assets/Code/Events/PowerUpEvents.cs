using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEvents
{
    public delegate void PowerUpSpawn(EPowerUpType type, Vector2 location);
    public static PowerUpSpawn powerUpSpawn;

    public delegate void ExecutePowerUp(EPowerUpType type);
    public static ExecutePowerUp executePowerUp;
}
