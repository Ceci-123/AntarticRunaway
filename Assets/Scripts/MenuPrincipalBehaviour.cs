// ============================================================================
// Proyecto: Antartic Runaway
// Autor: Maria Cecilia Calanna (Ceci)
// Fecha de Creación: 15/09/2026
// Versión: 1.0.0
// Descripción: Juego shooter 
// ============================================================================

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [Header("Paneles del Menú")]
    public GameObject panelPortada;
    public GameObject panelCreditos;

    void Start()
    {
        // Al iniciar el juego, mostrar la portada y ocultar créditos
        MostrarPortada();
    }

    
    /// <summary>
    /// Oculta el panel de la portada y activa el panel de créditos en la interfaz de usuario.
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    public void MostrarCreditos()
    {
        Debug.Log("Botón créditos presionado");
        Debug.Log("panelPortada es: " + panelPortada);
        if (panelPortada != null)
        {
            panelPortada.SetActive(false);
            Debug.Log("panelPortada.activeSelf ahora es: " + panelPortada.activeSelf);
        }
        if (panelCreditos != null) panelCreditos.SetActive(true);
        //if (panelPortada != null) panelPortada.SetActive(false);
        //if (panelCreditos != null) panelCreditos.SetActive(true);
    }

    /// <summary>
    /// Oculta el panel de créditos y activa el panel de la portada en la interfaz de usuario.
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    public void MostrarPortada()
    {
        if (panelPortada != null) panelPortada.SetActive(true);
        if (panelCreditos != null) panelCreditos.SetActive(false);
    }

    /// <summary>
    /// Registra un mensaje de debug en la consola y cambia a la escena llamada "Juego".
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    public void Jugar()
    {
        Debug.Log("Cargando el juego...");
        SceneManager.LoadScene("Juego");

    }
}