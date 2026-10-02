/**
 * * @Project Antartic Runaway
 * @fileoverview Clase de corazoncitos para gestionar la visualizacion de las vidas.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-09-30 15:35
 * @lastModified 2026-09-30 15:35
 * @lastModifiedBy Ceci
 * 
 * Copyright (c) 2026 - Todos los derechos reservados.
 */
using UnityEngine;
using UnityEngine.UI;

public class CorazonesUI : MonoBehaviour
{
    [Header("Referencias")]
    public VidasJugador jugador;
    public Image[] corazones;

    [Header("Sprites (opcional)")]
    public Sprite corazonLleno;
    public Sprite corazonVacio;
   
    void Start()
    {
        if (jugador == null) return;

        jugador.VidasCambiaron += Actualizar;
        Actualizar(jugador.vidasActuales);
    }

    /// <summary>
    /// Se desuscribe del evento on destroy 
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    void OnDestroy()
    {
        if (jugador != null)
        {
            jugador.VidasCambiaron -= Actualizar;
        }
    }

    /// <summary>
    /// Recorre el array de corazones para determinar si debe colocarse el sprite de lleno o de vacio
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    void Actualizar(int vidas)
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            bool lleno = i < vidas;

            if (corazonLleno != null && corazonVacio != null)
            {
                corazones[i].sprite = lleno ? corazonLleno : corazonVacio;
            }
            else
            {
                corazones[i].enabled = lleno;
            }
        }
    }
}
