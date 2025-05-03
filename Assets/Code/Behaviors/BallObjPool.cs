using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Meant to Pool the ball objects
/// 
/// Since the number of Balls may not be static, lets dynamically spawn them if needed
/// with the caveat that the ball won't get destroyed. 
/// </summary>

public class BallObjPool
{
    private GameObject _ballPfb;
    private List<GameObject> _ballObjs;

    public BallObjPool(GameObject prefab)
    {
        _ballPfb = prefab;
        _ballObjs = new List<GameObject>();
    }

    public GameObject getBall()
    {
        GameObject ball;
        if (_ballObjs.Count < 1)
        {
            ball = spawnBall();
            return ball;
        }
        ball = _ballObjs[0];
        _ballObjs.Remove(ball);
        return ball;
    }

    public GameObject spawnBall()
    {
        GameObject ball = Object.Instantiate(_ballPfb);
        ball.SetActive(false);//no need to be visible before the controller/manager want it to be
        return ball;
    }

    public void returnToPool(GameObject ball)
    {
        ball.SetActive(false);
        _ballObjs.Add(ball);
    }
}
