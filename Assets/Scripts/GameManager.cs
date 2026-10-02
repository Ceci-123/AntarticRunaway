/**
 * * @Project Antartic Runaway
 * @fileoverview Clase game manager. para controlar el flujo del juego, la condición de victoria/derrota y el conteo de enemigos.
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


    /// <summary>
    /// Implementa el patrón Singleton. Garantiza que solo exista una instancia activa de este script en toda la escena.
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
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

    /// <summary>
    /// Prepara el estado inicial del nivel, restablece la velocidad del tiempo a lo normal y oculta el panel de fin de juego
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    private void Start()
    {
        Time.timeScale = 1f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    /// <summary>
    /// Incrementa el contador de enemigos en uno
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    public void RegistrarEnemigo()
    {
        enemigosVivos++;
    }

    /// <summary>
    /// Asigna el valor true a la variable generacion terminada y llama a la funcion ComprobarFin
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    public void FinalizarGeneracion()
    {
        generacionTerminada = true;
        ComprobarFin();
    }

    /// <summary>
    /// Resta 1 al contador de enemigos,y llama a la funcion ComprobarFin
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    public void OnEnemyKilled()
    {
        enemigosVivos--;
        ComprobarFin();
    }

    /// <summary>
    /// Verifica si se cumple la condición para ganar para llamar al metodo que gestiona si ganaste
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    private void ComprobarFin()
    {
        if (generacionTerminada && enemigosVivos <= 0)
        {
            Victoria();
        }
    }

    /// <summary>
    /// Llama al método privado TerminarJuego() enviándole el texto correspondiente diciendo que ganaste
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    public void Victoria()
    {
        TerminarJuego("¡Ganaste!");
    }

    /// <summary>
    /// Llama al método privado TerminarJuego() enviándole el texto correspondiente diciendo que el juego termino
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    public void Derrota()
    {
        TerminarJuego("Game Over");
    }

    /// <summary>
    /// Usa la variable juegoTerminado para evitar que se ejecute dos veces, muestra el panel de fin de juego en la UI y detiene el juego
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    private void TerminarJuego(string mensaje)
    {
        
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

        Time.timeScale = 0f; 
    }

    /// <summary>
    /// Reinicia el juego
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    // Lo llama el botón Reiniciar
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}