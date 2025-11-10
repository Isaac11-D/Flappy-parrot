using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //Fisicas
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public GameController gameController;  // ← Ya no usas instance
    public AudioSource SonidoVuelo;        // ← AudioSource, NO GameObject
    public AudioSource SonidoMuerte;       // ← AudioSource, NO GameObject

    //Variables Globales
    private bool EstaMuerto;
    public float FuerzaSalto = 200f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (EstaMuerto) return;

        if (Input.GetMouseButtonDown(0))
        {
            rigidbody2D.linearVelocity = Vector2.zero;
            rigidbody2D.AddForce(Vector2.up * FuerzaSalto);
            animator.SetTrigger("Volar");

            if (SonidoVuelo != null)
                SonidoVuelo.Play();  // ← .Play() en vez de Instantiate
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (EstaMuerto) return; // Evita doble muerte

        EstaMuerto = true;
        animator.SetTrigger("Muerte");

        if (SonidoMuerte != null)
            SonidoMuerte.Play();  // ← .Play() en vez de Instantiate

        // Llama al Game Over
        if (gameController != null)
            gameController.MurcielagoMuerto();  // ← Usa el objeto asignado
        else
            GameController.instance.MurcielagoMuerto(); // ← Alternativa si usas singleton
    }
}
