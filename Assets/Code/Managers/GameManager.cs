using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// High level orchestration of the game
///
/// setup settings and orchestrate game events
/// </summary>

public class GameManager : MonoBehaviour
{
    public GameObject boundingBox;
    public int rowCount;
    public int columnCount;

    public int startingLevelOffset = 0;

    [Range(0,1f)]
    public float powerUpChance;

    private int roundCount = 0;

    private void Awake()
    {
        setupSettings();
        GameManagerEvents.levelComplete += advanceLevel;
        InputHandler input = InputHandler.instance;//start monobehavior methods
    }

    private void Start()
    {
        GameManagerEvents.loadLevel?.Invoke(roundCount);
    }

    private void advanceLevel()
    {
        roundCount++;
        GameManagerEvents.loadLevel?.Invoke(roundCount);
    }

    private void setupSettings()
    {
        Settings.instance.gameWidth = boundingBox.GetComponent<SpriteRenderer>().bounds.size.x;
        Settings.instance.gameHeight = boundingBox.GetComponent<SpriteRenderer>().bounds.size.y;
        Settings.instance.brickGridWidth = columnCount;
        Settings.instance.brickGridHeight = rowCount;
        Settings.instance.startLevel = startingLevelOffset;
        Settings.instance.powerUpOdds = powerUpChance;
    }

}
