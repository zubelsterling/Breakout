using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour, IBrickController
{
    //AudioSystem audio;

    private void Awake()
    {
        //audio = AudioSystem.instance.getInstance();
    }

    public void hit()
    {
        this.gameObject.SetActive(false);
    }

}
