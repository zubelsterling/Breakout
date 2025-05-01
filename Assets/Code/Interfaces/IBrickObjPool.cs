using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBrickObjPool
{
    GameObject pop();
    void add(GameObject g);
}
