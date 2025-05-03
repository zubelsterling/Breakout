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

    private BallObjPool pool;

    private List<GameObject> _activeBalls;

    [Range(5, 15)]
    public int maxNumBalls;

    private void Start()
    {
        _activeBalls = new List<GameObject>();
        pool = new BallObjPool(ballPrefab);
        eventSubscriptions();

        newBall();
    }

    private void eventSubscriptions()
    {
        BallEvents.ballOffScreen += offScreen;
        BallEvents.spawnExtraBall += spawnExtraBall;
    }

    private GameObject newBall()
    {
        if(_activeBalls.Count < maxNumBalls)
        {
            GameObject ball = pool.getBall();
            ball.transform.position = ballSpawnLocation();
            ball.SetActive(true);
            _activeBalls.Add(ball);
            return ball;

        }
        return null;
    }

    private void offScreen()
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

    private void spawnExtraBall()
    {
        newBall()?.GetComponent<BallController>().enableMovement();
    }

    private Vector3 ballSpawnLocation()
    {
        return new Vector3(0, -2, 0);//dont do a static thing here, its annoying
    }

}
