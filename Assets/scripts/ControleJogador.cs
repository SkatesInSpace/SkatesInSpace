using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    public bool inAir = false;
    public bool upsideDown = false;
    private Rigidbody2D rbJogador;
    private Camera mainCamera;

    void Start()
    {
        rbJogador = GetComponent<Rigidbody2D>();
        rbJogador.velocity = new Vector2(7f, 0);

    }
    void Update()
    {

        // float movimentoLateral = Input.GetAxis("Horizontal");
        // float movimentoVertical = Input.GetAxis("Vertical");

        // rbJogador.velocity = new Vector2( movimentoLateral * 7f, rbJogador.velocity.y);
        rbJogador.velocity = new Vector2(7f, rbJogador.velocity.y);
        if (!inAir && Input.GetKeyDown(KeyCode.Space))
        {
            inAir = true;
            Vector2 jumpVelocity = new Vector2(0, 9f);
            if (upsideDown) jumpVelocity *= -1;
            rbJogador.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }

        //pular
        if (Input.GetKeyDown(KeyCode.Return))
        {
            rbJogador.gravityScale *= -1;
            upsideDown = !upsideDown;
        }

        //inverter gravidade
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("basicPlatform") 
            // && CollisionManagement.hasHitTop(collision)
        )
        {
            inAir = false;
        }
    }
    
}