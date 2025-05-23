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
    public static  List<List<GameObject>> spawnBricks(GameObject brick, Vector3 startLoc)
    {
        List<List<GameObject>> resultRefs = new List<List<GameObject>>();
        Vector3 location = startLoc;
        GameObject currentBrick;
        int height = Settings.instance.brickGridHeight;
        int width = Settings.instance.brickGridWidth;

        for(int i = 0; i < height; i++)
        {
            location.y -= brick.GetComponent<Renderer>().bounds.size.y; ;
            location.x = startLoc.x - brick.GetComponent<Renderer>().bounds.size.x/2;
            resultRefs.Add(new List<GameObject>());
            for(int j = 0; j < width; j++)
            {
                //create new obj in loop to allocate the memory
                currentBrick = Object.Instantiate(brick);
                currentBrick.SetActive(false);
                location.x += brick.GetComponent<Renderer>().bounds.size.x;
                currentBrick.transform.position = location;
                currentBrick.GetComponent<BrickController>().setColor(i);
                resultRefs[i].Add(currentBrick);
            }
        }
        return resultRefs;
    }

}
