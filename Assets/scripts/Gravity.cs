using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private static bool upsideDown = false;
    private GameObject player;
    private Rigidbody2D rbJogador;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        rbJogador = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rotatePlayerIfNeeded();
    }

    private void rotatePlayerIfNeeded()
    {

        if (upsideDown && rbJogador.rotation > 178 && rbJogador.rotation < 182)
        {
            rbJogador.transform.Rotate(Vector3.forward * 0);
        }
        else if (!upsideDown && rbJogador.rotation > -2 && rbJogador.rotation < 2)
        {
            rbJogador.transform.Rotate(Vector3.forward * 0);
        }
        else
        {
            Vector3 rotationSpeed = Vector3.forward * 360 * Time.deltaTime;
            if (upsideDown) rotationSpeed *= -1;
            rbJogador.transform.Rotate(rotationSpeed);
        }
    }

    public static bool isUpsideDown() {
        return upsideDown;
    }

    
    public static void invertGravity(Rigidbody2D rbPlayer) {
        rbPlayer.gravityScale *= -1;
        upsideDown = !upsideDown;
    }

}
