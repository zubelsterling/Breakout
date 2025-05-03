using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the resulting direction after a collision
/// 
/// I am implementing a simpleBounce method and a complexBounce method.
/// Based on the base game, the ball would hit a brick and mirror the x or y
/// however, as stated by the voice over, when the platform is hit there are 6 distinct possible launch angles.
/// </summary>

public class BallCollisionBehavior
{
    //look if the ball hit the top/left/right/bottom of something and reflect properly.
    public Vector2 simpleBounce(GameObject ball, GameObject target)
    {
        Vector2 ballPosition = ball.transform.position;
        Vector2 targetPosition = target.transform.position;

        float targetHeight = target.GetComponent<Renderer>().bounds.size.y/2;


        int x = 1;
        int y = 1;
        
        //top or bottom hit
        if(ballPosition.y < targetPosition.y - targetHeight || ballPosition.y > targetPosition.y + targetHeight)
        {
            y = -1;
        }
        else//side hit
        {
            x = -1;
        }

        return new Vector2(x, y);

    }

    //platform reflections should be 6 distinct launch angles
    //Approach - I could simulate a curved surface, but I'd rather just calculate
    //          based on the dinstance from the center point of the platform.
    public Vector2 platformBounce(GameObject ball, GameObject target)
    {
        //based on x distance from the center of the platform, set launch angle.
        float low = 0.25f;
        float med = 0.5f;
        float high = 1f;
        int xDirection = 0;

        float resultX = 0;
        float resultY = 0;

        xDirection = ball.transform.position.x < target.transform.position.x ? -1 : 1;

        float calculatedDistance = (Mathf.Abs(ball.transform.position.x) - Mathf.Abs(target.transform.position.x)) / target.GetComponent<Renderer>().bounds.size.x;

        if ( calculatedDistance < 0.3f)
        {
            resultX = low;
        }
        else if(calculatedDistance < 0.6f)
        {
            resultX = med;
        }
        else
        {
            resultX = high;
        }
        resultY =  2f - resultX;

        return new Vector2(resultX * xDirection, resultY);
    }
}
