using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private const int _TOPLOC = 5;
    private const int _BOTTOMLOC = -5;
    private const int _LEFTLOC = -10;
    private const int _RIGHTLOC = 10;

    private float _xVel = 0.1f;
    private float _yVel = 0.1f;

    private bool shouldUpdate = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldUpdate)
        {


            if (this.transform.position.x < _LEFTLOC || this.transform.position.x > _RIGHTLOC)
            {
                _xVel *= -1;
            }
            if (this.transform.position.y > _TOPLOC || this.transform.position.y < _BOTTOMLOC)
            {
                _yVel *= -1;
            }

            this.transform.position = new Vector3(this.transform.position.x + _xVel, this.transform.position.y + _yVel, this.transform.position.z);
        }
        shouldUpdate = !shouldUpdate;
    }
}
