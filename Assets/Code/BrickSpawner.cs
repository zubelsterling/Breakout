using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawn brick and set position to a static grid.
/// 
/// ideally do this in a generic way and just return the result.
/// static function allows for running this without a hard link.
/// </summary>

public class BrickSpawner
{
    //only run once, don't destroy bricks since enable/disable is way cheaper
    public static  List<List<GameObject>> spawnBricks(int height, int width, GameObject brick, Vector2 startLoc)
    {
        List<List<GameObject>> resultRefs = new List<List<GameObject>>();
        Vector3 location = new Vector3(0, 0, 0);
        GameObject currentBrick;

        for(int i = 0; i < height; i++)
        {
            location.y += brick.GetComponent<Renderer>().bounds.size.y; ;
            location.x = 0;
            resultRefs.Add(new List<GameObject>());
            for(int j = 0; j < width; j++)
            {
                //create new obj in loop to allocate the memory
                currentBrick = Object.Instantiate(brick);
                currentBrick.SetActive(false);
                location.x += brick.GetComponent<Renderer>().bounds.size.x;
                currentBrick.transform.position = location;
                resultRefs[i].Add(currentBrick);
            }
        }
        return resultRefs;
    }

}
