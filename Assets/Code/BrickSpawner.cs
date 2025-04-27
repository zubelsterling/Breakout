using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public IBrickObjPool brickObjPool; //attach which spawner to use
    public GameObject brickObject;


    void Start()
    {
        spawnBricks(10, 5);
    }

    public List<GameObject> spawnBricks(int width, int height)
    {
        brickObjPool = new BrickObjPool(brickObject);
        List<GameObject> resultRefs = new List<GameObject>();
        int x, y;
        Vector3 location = new Vector3(0, 0, 0);

        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                GameObject g = brickObjPool.pop();

               
                g.transform.SetParent(transform);

                location.x = this.transform.position.x + j;
                location.y = this.transform.position.y - i;

                g.transform.position = location;
                g.SetActive(true);
            }
        }

        return resultRefs;
    }
}
