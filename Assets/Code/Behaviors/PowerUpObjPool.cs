using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObjPool : IPowerUpObjPool
{
    private List<GameObject> powerUpObjs;
    private GameObject temp;

    public GameObject pop()
    {
        if(powerUpObjs.Count > 0)
        {
            temp = powerUpObjs[0];
            powerUpObjs.Remove(temp);
            return temp;
        }
        return null;
    }

    public void returnToPool(GameObject g)
    {
        powerUpObjs.Add(g);
        g.SetActive(false);
    }

    public void fillPool(int size, GameObject prefab)
    {
        int i = size;
        powerUpObjs = new List<GameObject>();
        while(i > 0)
        {
            temp = Object.Instantiate(prefab);
            temp.SetActive(false);
            powerUpObjs.Add(temp);
            i--;
        }
    }
}
