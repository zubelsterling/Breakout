using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents
{
    public delegate void BrickBreakSound();
    public static BrickBreakSound brickBreakSound;

    public delegate void PowerUpCollectSound();
    public static PowerUpCollectSound powerUpCollectSound;

    public delegate void PlatformBounceSound();
    public static PlatformBounceSound platformBounceSound;

}
