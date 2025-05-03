using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ball manager is meant to be placed in the scene to manage 1 or many balls.
/// 
/// Should ensure 1 ball is onscreen at all times.
/// </summary>

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab;

    public delegate void BallOffScreen();
    public static BallOffScreen ballOffScreen;

    private BallObjPool pool;

    private List<GameObject> _activeBalls;

    private void Start()
    {
        _activeBalls = new List<GameObject>();
        pool = new BallObjPool(ballPrefab);
        ballOffScreen += offScreen;
        newBall();
    }

    public void newBall()
    {
        GameObject ball = pool.getBall();
        ball.transform.position = ballSpawnLocation();
        ball.SetActive(true);
        _activeBalls.Add(ball);

    }

    public void offScreen()
    {
        int i = 0;
        while(i < _activeBalls.Count) 
        {
            if(_activeBalls[i].transform.position.y < - 5)
            {
                pool.returnToPool(_activeBalls[i]);
                _activeBalls.Remove(_activeBalls[i]);
            }
            i++;
        }
        if(_activeBalls.Count < 1)
        {
            newBall();
        }
    }

    private Vector3 ballSpawnLocation()
    {
        return new Vector3(0, -2, 0);//dont do a static thing here, its annoying
    }

}
