using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// settings class to easily get things like screen width etc.
/// 
/// I am at odds with what would be able to edit these settins,
/// but they are settings afterall, they should be editable
/// </summary>

public class Settings : Singleton<Settings>
{
    public float gameWidth { get; set; }
    public float gameHeight { get; set; }
    public float powerUpOdds { get; set; }
    public int brickGridWidth { get; set; }
    public int brickGridHeight { get; set; }
    public int startLevel { get; set; }

}
