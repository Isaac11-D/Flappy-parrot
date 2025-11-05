using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // AÑADE ESTO

public class GameManager : MonoBehaviour
{
    public Renderer Fondo;

    void Start()
    {
        // Opcional: reiniciar offset al inicio
        if (Fondo != null)
            Fondo.material.mainTextureOffset = Vector2.zero;
    }

    void Update()
    {
        // NOMBRE EXACTO DE TU ESCENA DE MENÚ
        string escenaActual = SceneManager.GetActiveScene().name;

        // Cambia "Menu" por el nombre real de tu escena
        if (escenaActual == "Menus" || escenaActual.Contains("Menus") || escenaActual == "Leaderboards" || escenaActual.Contains("Leaderboards"))
        {
            return; // NO mueve el fondo en el menú
        }

        // Movimiento solo en juego
        Fondo.material.mainTextureOffset += new Vector2(0.015f, 0) * Time.deltaTime;
    }
}