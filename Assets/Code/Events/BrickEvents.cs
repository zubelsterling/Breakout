using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickEvents : MonoBehaviour
{
    public delegate void BrickHit();
    public static BrickHit brickHit;
}
