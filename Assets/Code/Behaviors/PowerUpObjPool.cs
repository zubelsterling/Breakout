using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PowerUpObjPool
{
    GameObject pop();
    GameObject returnToPool();
    GameObject fillPool();
}
