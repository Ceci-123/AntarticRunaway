/**
 * @Project Antartic Runaway
 * @fileoverview Comportamiento del menu principal
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-09-30 14:35
 * @lastModified 2026-09-30 14:35
 * @lastModifiedBy Ceci
 * 
 * Copyright (c) 2026 - Todos los derechos reservados.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [Header("Paneles del Menú")]
    public GameObject panelPortada;
    public GameObject panelCreditos;

    void Start()
    {
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
        if (panelPortada != null) panelPortada.SetActive(false);
        if (panelCreditos != null) panelCreditos.SetActive(true);
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