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

    public GameObject boundingBox;

    private void Awake()
    {
        Settings.instance.gameWidth = boundingBox.GetComponent<SpriteRenderer>().bounds.size.x; 
        Settings.instance.gameHeight = boundingBox.GetComponent<SpriteRenderer>().bounds.size.y; 
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

}
