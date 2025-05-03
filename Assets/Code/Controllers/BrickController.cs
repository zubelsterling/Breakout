using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour, IBrickController
{
    Color[] colors = {Color.red, Color.magenta,new Color(1f, 0.60f, 0f), Color.yellow, Color.green, Color.cyan, new Color(0, 0.75f, 0.75f), Color.blue};
    public void setColor(int height)
    {
        GetComponent<MeshRenderer>().material.color = colors[height];
    }
    public void hit()
    {
        if (shouldSpawnPowerUp())
        {
            PowerUpEvents.powerUpSpawn?.Invoke(EPowerUpType.EXTRABALL, transform.position);
        }
        gameObject.SetActive(false);
        BrickEvents.brickHit?.Invoke();
    }

    private bool shouldSpawnPowerUp()
    {
        float r = Random.Range(0, 100);
        return r < Settings.instance.powerUpOdds * 100;
    }
}
