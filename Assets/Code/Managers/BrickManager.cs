using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class for managing bricks, keeping track of how many are still on screen
/// 
/// only concern is managing the bricks. So it should just be told when to update the 
/// layout and handle that orchestration
/// </summary>


public class BrickManager : MonoBehaviour
{

    private List<List<GameObject>> _bricks;
    private List<List<string>> _layout;
    private int _activeBrickCount;

    public GameObject spawnPoint;
    public GameObject brickPrefab;

    public TextAsset[] levels;


    private void Awake()
    {
        GameManagerEvents.loadLevel += loadLevel;
        BrickEvents.brickHit += decreaseActiveBrickCount;
    }

    void Start()
    {
        _bricks = BrickSpawner.spawnBricks(brickPrefab, spawnPoint.transform.position);

    }

    public void updateBrickLayout(List<List<string>> layout)
    {
        _activeBrickCount = 0;

        //replace this with settings
        int width = Settings.instance.brickGridWidth;
        int height = Settings.instance.brickGridHeight;

        for (int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                if(layout[i][j] != null)
                {
                    if (shouldActiveateBrick(layout[i][j]))
                    {
                        _activeBrickCount++;
                        _bricks[i][j].SetActive(true);
                    }
                }

            }
        }
    }

    private bool shouldActiveateBrick(string s)
    {
        if(s == "1")
        {
            return true;
        }
        return false;
    }

    public void decreaseActiveBrickCount()
    {
        _activeBrickCount--;
        if(_activeBrickCount < 1)
        {
            GameManagerEvents.levelComplete?.Invoke();
        }
    }

    private void loadLevel(int level)
    {
        //clamp level to fit into array and allow for an offset if it exists
        int adjustedLevelNum = (level + Settings.instance.startLevel) % levels.Length;
        _layout = BrickLayoutConfig.getLayout(levels[adjustedLevelNum]);
        updateBrickLayout(_layout);
    }
}
