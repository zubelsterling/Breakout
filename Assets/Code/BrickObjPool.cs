using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object pool for bricks.
/// 
/// statically defining the number of bricks for now, possibly going to dynamically
/// allocate, and keep any unused instance in this class
/// </summary>
public class BrickObjPool : ScriptableObject, IBrickObjPool
{
    private List<GameObject> bricks; //keeping it generic for now.
    private int poolSize = 12 * 12;

    public BrickObjPool(GameObject brick)
    {
        bricks = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            var t = Instantiate(brick);
            t.SetActive(false);
            bricks.Add(t);
        }
    }

    public GameObject pop()
    {
        GameObject output = bricks[0];
        bricks.Remove(output);
        return output;
    }

    public void add(GameObject g)
    {
        bricks.Add(g);
    }
}
