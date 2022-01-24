using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GerenciaJogo : MonoBehaviour
{
    // float pontosJogo;
    // int vidas;
    // public TextMeshProUGUI txtVidas;
    // public TextMeshProUGUI txtPontos;
    // public TextMeshProUGUI txtGameOver;
    // Start is called before the first frame update
    void Start()
    {
        // pontosJogo = 0;
        // vidas = 3;
        // txtGameOver.enabled = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("Ouro"))
        // {
        //     //Aumentar os pontos
        //     pontosJogo = pontosJogo + 50;
 

        //     //Exibir em tela a mudan�a
        //     txtPontos.SetText("Pontos: " + pontosJogo);
        //     //Destruir a moeda
        //     Destroy(collision.gameObject);
        // }

        // if (collision.gameObject.CompareTag("Asteroide"))
        // {
        //     //Diminuir a vida
        //     vidas = vidas - 1;


        //     //Exibir em tela a mudan�a
        //     txtVidas.SetText("Vidas: " + vidas);
        //     //Destruir a moeda
        //     Destroy(collision.gameObject);

        //     if(vidas <= 0)
        //     {
        //         txtGameOver.enabled = true;
        //     }
        // }
    }
}
