using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEvents
{
    public delegate void LoadLevel(int levelNum);
    public delegate void LevelComplete();

    public static LoadLevel loadLevel;
    public static LevelComplete levelComplete;
}
