using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ConfigFileType
{
    CSV,
    TXT,
    JSON
}

public class BrickSpawner : MonoBehaviour
{
    public IBrickObjPool brickObjPool; //attach which spawner to use
    private IConfigInterpreter config;
    public GameObject brickObject;


    void Start()
    {
        config = GetComponent<IConfigInterpreter>();
        spawnBricks(config.getLayout(1));
    }

    public List<GameObject> spawnBricks(List<List<string>> bricks)
    {
        brickObjPool = new BrickObjPool(brickObject);
        List<GameObject> resultRefs = new List<GameObject>();
        Vector3 location = new Vector3(0, 0, 0);

        for(int i = 0; i < bricks.Count; i++)
        {
            for(int j = 0; j < bricks[i].Count; j++)
            {
                if (bricks[i][j] != "0")
                {
                    GameObject g = brickObjPool.pop();


                    //could set what KIND of brick using numbers eg 2,3,4
                    g.transform.SetParent(transform);

                    location.x = this.transform.position.x + j;
                    location.y = this.transform.position.y - i;

                    g.transform.position = location;
                    g.SetActive(true);
                }
            }
        }

        return resultRefs;
    }
}
