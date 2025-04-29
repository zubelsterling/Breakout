using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IBrickController
{
    void hit();
}

public class BrickController : MonoBehaviour, IBrickController
{

    public void hit()
    {
        Debug.Log("AH IVE BEEN HIT");
        this.gameObject.SetActive(false);
    }

}
