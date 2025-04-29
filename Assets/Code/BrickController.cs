using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IBrickController
{
    void hit();
}

public class BrickController : MonoBehaviour, IBrickController
{
    AudioSystem audio;

    private void Awake()
    {
        audio = AudioSystem.instance.getInstance();
    }

    public void hit()
    {
        Debug.Log("AH IVE BEEN HIT");
        this.gameObject.SetActive(false);
    }

}
