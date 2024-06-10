using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Jogador : MonoBehaviour
{
    public Rigidbody2D rb;

    public float forcaPulo;

    public LayerMask layerChao;

    public bool estaNoChao;

    public float distanciaMinimaChao = 1;

    private float pontos;

    public float multiplicadorPontos = 1;

    public TMP_Text pontosText;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        pontos += Time.deltaTime * multiplicadorPontos;

        pontosText.text = pontos.ToString("Pontos: 0.0");

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
        }
    }

    void Pular()
    {
        if(estaNoChao)
        {
            rb.AddForce(Vector2.up * forcaPulo);
        }
        
       
    }

    private void FixedUpdate()
    {
        estaNoChao  = Physics2D.Raycast(transform.position, Vector2.down, distanciaMinimaChao, layerChao);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Inimigo"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
