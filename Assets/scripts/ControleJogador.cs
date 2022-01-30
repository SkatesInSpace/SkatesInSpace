using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    public bool inAir = false;
    private Rigidbody2D rbJogador;
    private GameObject floor;

    void Start()
    {
        rbJogador = GetComponent<Rigidbody2D>();
        rbJogador.velocity = new Vector2(7f, 0);
        floor = ObjectHandler.getFloor();
    }
    void Update()
    {

        rbJogador.velocity = new Vector2(7f, rbJogador.velocity.y);

        //pular
        if (!inAir && Input.GetKeyDown(KeyCode.Space)) jump();
        
        
        //inverter gravidade
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Gravity.invertPlatforms();

            Debug.Log("InvertPlatform");
            // Vector3 rotationPoint = new Vector3 (rbJogador.transform.position.x, floor.transform.position.y, 0);
            // transform.RotateAround(rotationPoint, transform.right, 180f);
            if(isInTheFloor()) {
                Debug.Log("floor");
                Vector3 rotationPoint = new Vector3 (rbJogador.transform.position.x, floor.transform.position.y, 0) ;
                transform.RotateAround(rotationPoint, transform.right, 180f);
            }
        }

        
    }

    public bool isInTheFloor() {
        float positionY = rbJogador.position.y - GetComponent<Renderer>().bounds.size.y/2; 
        return !inAir && positionY < 1 && positionY > -1;
    } 

    //To be used in case of debug
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