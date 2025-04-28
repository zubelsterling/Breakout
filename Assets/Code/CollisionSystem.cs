using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collision system for the ball
/// 
/// The temptation here is to rely on Unity's collision handling,
/// however, I would prefer to do this calculation myself in this project
/// due to things I noticed about the source material
/// 
/// considerations
/// 1. In the original breakout game, there were 8 directions the ball could take, instead of infinite.
/// 2. I noticed that at higher speed the ball could skip over some blocks because it only checked the target location
///     and not the path along the way. I want to allow the player to change between classic and modern physics.
/// </summary>

public class CollisionSystem : MonoBehaviour
{

    //This class will only do the math, it will not run every loop. It is intended to be called.


    public void checkCollision()
    {

    }
}
