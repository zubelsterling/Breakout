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
    public int brickGridWidth;
    public int brickGridHeight;
    public GameObject brickPrefab;

    public TextAsset[] levels;


    private void Awake()
    {
        GameEvents.loadLevel += loadLevel;
    }

    void Start()
    {
        _bricks = BrickSpawner.spawnBricks(brickGridHeight, brickGridWidth, brickPrefab, spawnPoint.transform.position);

    }

    public void updateBrickLayout(List<List<string>> layout)
    {
        _activeBrickCount = 0;

        //use whichever width/height that is smallest
        int width = layout.Count < _bricks.Count ? layout.Count : _bricks.Count;
        int height = layout[0].Count < _bricks[0].Count ? layout[0].Count : _bricks[0].Count;

        for (int i = 0; i < _bricks.Count; i++)
        {
            for(int j = 0; j < _bricks[i].Count; j++)
            {

                if (shouldActiveateBrick(layout[i][j]))
                {
                    _activeBrickCount++;
                    _bricks[i][j].SetActive(true);
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
            GameEvents.levelComplete?.Invoke();
        }
    }

    private void loadLevel(int level)
    {
        _layout = BrickLayoutConfig.getLayout(levels[level]);
        updateBrickLayout(_layout);
    }
}
