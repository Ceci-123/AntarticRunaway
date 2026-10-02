/**
 * * @Project Antartic Runaway
 * @fileoverview Clase de vidas del jugador.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-09-30 15:04
 * @lastModified 2026-09-30 16:14
 * @lastModifiedBy Ceci
 * 
 * Copyright (c) 2026 - Todos los derechos reservados.
 */
using UnityEngine;
using System;
using System.Collections;

public class VidasJugador : MonoBehaviour
{
    [Header("Vidas")]
    public int vidasMaximas = 3;
    public int vidasActuales;

    [Header("Invulnerabilidad tras un golpe")]
    public float tiempoInvulnerable = 1.5f;
    public float velocidadParpadeo = 0.1f;


    public event Action<int> VidasCambiaron;

    private bool invulnerable = false;
    private SpriteRenderer sprite;

    /// <summary>
    /// Inicializa el objeto al valor maximo de vidas y asigna a una variable la referencia del componente para utilizarla luego.
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    void Awake()
    {
        vidasActuales = vidasMaximas;
        sprite = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Verifica si el personaje puede recibir daño, si es asi, resta una vida y dispara el evento de la UI.
    /// Si se quedo sin vidas, muere y si no, llama al metodo de invunerabilidad
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    public void RecibirDanio()
    {
        if (invulnerable || vidasActuales <= 0) return;

        vidasActuales--;
     
        VidasCambiaron?.Invoke(vidasActuales);

        if (vidasActuales <= 0)
        {
            Morir();
        }
        else
        {
            StartCoroutine(Invulnerabilidad());
        }
    }

    /// <summary>
    /// Desactiva el personaje y notifica al game manager.
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    void Morir()
    {
        

        if (GameManager.Instance != null)
        {
            GameManager.Instance.Derrota();
        }

        gameObject.SetActive(false);
    }

    /// <summary>
    /// Le da al personaje un momento de invunerabilidad para que no reciba daño.
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    IEnumerator Invulnerabilidad()
    {
        invulnerable = true;
        float tiempo = 0f;

        while (tiempo < tiempoInvulnerable)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(velocidadParpadeo);
            tiempo += velocidadParpadeo;
        }

        sprite.enabled = true;
        invulnerable = false;
    }
}
