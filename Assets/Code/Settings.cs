using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// settings class to easily get things like screen width etc.
/// </summary>

public class Settings : Singleton<Settings>
{
    public float gameWidth { get; set; }
    public float gameHeight { get; set; }
    public float powerUpOdds { get; set; }

}
