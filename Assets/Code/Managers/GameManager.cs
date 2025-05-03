using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// High level orchestration of the game
///
/// </summary>

public class GameManager : MonoBehaviour
{
    private int roundCount = 0;

    private void Awake()
    {
        GameEvents.levelComplete += advanceLevel;
        InputHandler input = InputHandler.instance;//start monobehavior methods
    }

    private void Start()
    {
        GameEvents.loadLevel?.Invoke(roundCount);
    }

    private void advanceLevel()
    {
        roundCount++;
        GameEvents.loadLevel?.Invoke(roundCount);
    }

}

/// <summary>
/// some game events that any class can subscribe to
/// </summary>
public static class GameEvents
{
    public delegate void LoadLevel(int levelNum);
    public delegate void LevelComplete();

    public static LoadLevel loadLevel;
    public static LevelComplete levelComplete;
}
