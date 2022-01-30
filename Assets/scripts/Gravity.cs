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

    }

    private void LateUpdate() {
        rotatePlayerIfNeeded();
    }


    private void rotatePlayerIfNeeded()
    {

        if (upsideDown && rbPlayer.rotation > 160 && rbPlayer.rotation < 200)
        {
            // rbPlayer.transform.Rotate(Vector3.forward * 0);
            Debug.Log(rbPlayer.transform.eulerAngles);
            rbPlayer.transform.eulerAngles = new Vector3(0,0,180);
        }
        else if (!upsideDown && rbPlayer.rotation > -20 && rbPlayer.rotation < 20)
        {
            // rbPlayer.transform.Rotate(Vector3.forward * 0);
            rbPlayer.transform.eulerAngles = new Vector3(0,0,0);
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
