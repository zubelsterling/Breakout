using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerUpObjPool
{
    GameObject pop();
    void returnToPool(GameObject powerUp);
    void fillPool(int size, GameObject g);
}
