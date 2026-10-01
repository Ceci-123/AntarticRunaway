/**
 * * @Project Antartic Runaway
 * @fileoverview Clase game manager.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-09-30 15:39
 * @lastModified 2026-10-01 16:04
 * @lastModifiedBy Ceci
 * 
 * Copyright (c) 2026 - Todos los derechos reservados.
 */
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Reference")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text textoFinal;

    private int enemigosVivos = 0;
    private bool generacionTerminada = false;
    private bool juegoTerminado = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void RegistrarEnemigo()
    {
        enemigosVivos++;
    }

    public void FinalizarGeneracion()
    {
        generacionTerminada = true;
        ComprobarFin();
    }

    public void OnEnemyKilled()
    {
        enemigosVivos--;
        Debug.Log("Enemigos vivos: " + enemigosVivos);
        ComprobarFin();
    }

    private void ComprobarFin()
    {
        if (generacionTerminada && enemigosVivos <= 0)
        {
            Victoria();
        }
    }

    public void Victoria()
    {
        TerminarJuego("¡Ganaste!");
    }

    public void Derrota()
    {
        TerminarJuego("Game Over");
    }

    private void TerminarJuego(string mensaje)
    {
        // Evita que se pise un final con otro (por ejemplo, un proyectil en vuelo
        // que mata a la última ballena después de que el jugador murió)
        if (juegoTerminado) return;
        juegoTerminado = true;

        if (textoFinal != null)
        {
            textoFinal.text = mensaje;
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f; // congela el juego
    }

    // Lo llama el botón Reiniciar
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}