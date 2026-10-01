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

    // Lo usaremos en el paso 4 para actualizar los corazones
    public event Action<int> VidasCambiaron;

    private bool invulnerable = false;
    private SpriteRenderer sprite;

    void Awake()
    {
        vidasActuales = vidasMaximas;
        sprite = GetComponent<SpriteRenderer>();
    }

    public void RecibirDanio()
    {
        if (invulnerable || vidasActuales <= 0) return;

        vidasActuales--;
        Debug.Log("Vidas: " + vidasActuales);
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
    void Morir()
    {
        Debug.Log("El jugador murió");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.Derrota();
        }

        gameObject.SetActive(false);
    }

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
