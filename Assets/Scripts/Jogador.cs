using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    public TMP_Text highscoreText;

    private float highscore;

    public GameObject reiniciarButton;

    public GameObject inicioGame;

    public TMP_Text jogarText; 

    //erro
    //public TMPro.Button jogarButton;

    
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("HIGHSCORE");
        highscoreText.text = highscore.ToString("Highscore: 0.0");

       //erro 
       // jogarButton.onClick.AddListener(IniciarJogo);
    }

    public void IniciarJogo()
    {
        // código para iniciar o jogo aqui
        Debug.Log("Jogo iniciado!");
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
            if(pontos > highscore)
            {
                highscore = pontos;

                PlayerPrefs.SetFloat("HIGHSCORE", highscore);
            }

            reiniciarButton.SetActive(true);


            Time.timeScale = 0;

        }
    }
}
