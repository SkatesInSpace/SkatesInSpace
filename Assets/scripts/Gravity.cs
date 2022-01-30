using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private static bool upsideDown = false;
    private static bool invertedPlatform = false;
    private GameObject player;
    private GameObject floor;
    private Rigidbody2D rbPlayer;

     void Start()
    {
        player = ObjectHandler.getPlayer();
        floor = ObjectHandler.getFloor();
        
        rbPlayer = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
        float playerY = player.transform.position.y;
        float floorY = floor.transform.position.y;
        if(playerY < floorY) rbPlayer.gravityScale = -3;
        if(playerY > floorY) rbPlayer.gravityScale = 3;

        // rotatePlayerIfNeeded();
    }


    private void rotatePlayerIfNeeded()
    {

        if (upsideDown && rbPlayer.rotation > 178 && rbPlayer.rotation < 182)
        {
            rbPlayer.transform.Rotate(Vector3.forward * 0);
        }
        else if (!upsideDown && rbPlayer.rotation > -2 && rbPlayer.rotation < 2)
        {
            rbPlayer.transform.Rotate(Vector3.forward * 0);
        }
        else
        {
            Vector3 rotationSpeed = Vector3.forward * 360 * Time.deltaTime;
            if (upsideDown) rotationSpeed *= -1;
            rbPlayer.transform.Rotate(rotationSpeed);
        }
    }

    public static bool isUpsideDown() {
        return upsideDown;
    }

    
    public static void invertGravity(Rigidbody2D rbPlayer) {
        rbPlayer.gravityScale *= -1;
        upsideDown = !upsideDown;
    }

    public static void invertPlatforms() {
        invertedPlatform = !invertedPlatform;
        upsideDown = !upsideDown;
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("basicPlatform");
        foreach (GameObject platform in platforms)
        {
            platform.GetComponent<PlatformEffector2D>().rotationalOffset = invertedPlatform ? 180 : 0;
        }
    }

}
