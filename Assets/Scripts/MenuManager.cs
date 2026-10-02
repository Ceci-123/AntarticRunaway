/**
 * * @Project Antartic Runaway
 * @fileoverview Clase de vidas del jugador.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-10-02 15:38
 * @lastModified 2026-10-02 15:38
 * @lastModifiedBy Ceci
 * 
 * Copyright (c) 2026 - Todos los derechos reservados.
 */
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Paneles de la UI")]
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
        panelPortada.SetActive(false);
        panelCreditos.SetActive(true);
    }

    /// <summary>
    /// Oculta el panel de creditos y activa el panel de portada en la interfaz de usuario.
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    public void MostrarPortada()
    {
        panelPortada.SetActive(true);
        panelCreditos.SetActive(false);
    }
}