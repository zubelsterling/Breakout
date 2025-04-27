using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private Player playerScriptRef;

    // Start is called before the first frame update
    void Start()
    {
        playerScriptRef = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
