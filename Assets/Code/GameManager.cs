using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerScriptRef;

    //private int roundCount = 0;//might be good to just have if I want to display this.

    // Start is called before the first frame update
    void Start()
    {
        playerScriptRef = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
