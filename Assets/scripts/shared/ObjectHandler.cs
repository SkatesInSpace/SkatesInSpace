using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    private static GameObject player;
    private static GameObject floor;
    void Start()
    {
        player = getPlayer();
        floor = getFloor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameObject getPlayer() {
        return player ? player : GameObject.Find("jogador");
    }

    public static GameObject getFloor() {
        return floor ? floor : GameObject.Find("floor");
    }
}
