using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem instance;

    public AudioSystem getInstance()
    {
        if (instance == null)
        {
            instance = this;
        }

        return instance;
    }

    public void brickBreak()
    {
        
    }

}
