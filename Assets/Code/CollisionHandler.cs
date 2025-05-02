using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

interface ICollisionHandler //put this in a new file
{
    void hit();//no params for now
}

public class CollisionHandler : MonoBehaviour
{
    private event Action onHit;

    public void hit()
    {
        onHit.Invoke();
    }

    public void getHitEvent(Delegate a)
    {
        //onHit += a;
    }
}
