/**
 * * @Project Antartic Runaway
 * @fileoverview Clase de comportaiento del jugador.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-09-30 14:35
 * @lastModified 2026-09-30 14:35
 * @lastModifiedBy Ceci
 * 
 * Copyright (c) 2026 - Todos los derechos reservados.
 */
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidad = 5f; 

    [Header("Límites de Pantalla (Eje X)")]
    public float limiteIzquierdo = -8f;
    public float limiteDerecho = 8f;

    [Header("Configuración de Disparo")]
    public GameObject prefabHielo; 
    public Transform puntoDisparo; 

    void Start()
    {
        float mitadAltura = Camera.main.orthographicSize;
        float mitadAncho = mitadAltura * Camera.main.aspect;
        limiteIzquierdo = -mitadAncho + 0.5f;
        limiteDerecho = mitadAncho - 0.5f;
    }
    void Update()
    {
       float entradaHorizontal = Input.GetAxisRaw("Horizontal");
       Vector3 nuevaPosicion = transform.position + new Vector3(entradaHorizontal * velocidad * Time.deltaTime, 0, 0);
       nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, limiteIzquierdo, limiteDerecho);
       transform.position = nuevaPosicion;
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            DispararHielo();
        }
    }

    /// <summary>
    /// Dispara el proyectil desde el punto de disparo.
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    void DispararHielo()
    {
        if (prefabHielo == null) return;
        Vector3 posicionSalida = (puntoDisparo != null) ? puntoDisparo.position : transform.position;
        Instantiate(prefabHielo, posicionSalida, Quaternion.identity);
    }
}