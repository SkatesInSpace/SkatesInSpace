using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    public bool inAir = false;
    private Rigidbody2D rbJogador;
    private Camera mainCamera;

    void Start()
    {
        rbJogador = GetComponent<Rigidbody2D>();
        rbJogador.velocity = new Vector2(7f, 0);

    }
    void Update()
    {

        rbJogador.velocity = new Vector2(7f, rbJogador.velocity.y);

        //pular
        if (!inAir && Input.GetKeyDown(KeyCode.Space)) jump();
        
        
        //inverter gravidade
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Gravity.invertGravity(rbJogador);
        }

        
    }

    //To be used in case of 
    private void movePlayer() {
        float movimentoLateral = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        rbJogador.velocity = new Vector2( movimentoLateral * 7f, rbJogador.velocity.y);
    }

    private void jump() {
            inAir = true;
            Vector2 jumpVelocity = new Vector2(0, 9f);
            if (Gravity.isUpsideDown()) jumpVelocity *= -1;
            rbJogador.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("basicPlatform") 
            // && CollisionManagement.hasHitTop(collision)
        )
        {
            inAir = false;
        }
    }
    
}