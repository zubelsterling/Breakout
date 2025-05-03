using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEvents
{
    public delegate void BallOffScreen();
    public static BallOffScreen ballOffScreen;

    public delegate void SpawnExtraBall();
    public static SpawnExtraBall spawnExtraBall;
}
