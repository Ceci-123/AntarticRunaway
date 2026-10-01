/**
 * * @Project Antartic Runaway
 * @fileoverview Clase disparo ballena.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-10-01 12:01
 * @lastModified 2026-10-01 12:01
 * @lastModifiedBy Ceci
 * 
 * Copyright (c) 2026 - Todos los derechos reservados.
 */
using UnityEngine;

public class DisparoBallena : MonoBehaviour
{
    [Header("Configuración del Disparo")]
    public GameObject prefabBurbuja;
    public Transform puntoDisparo;

    [Header("Tiempo entre disparos (segundos)")]
    public float intervaloMinimo = 2f;
    public float intervaloMaximo = 5f;

    private float temporizador;

    void Start()
    {
        ReiniciarTemporizador();
    }

    void Update()
    {
        temporizador -= Time.deltaTime;

        if (temporizador <= 0f)
        {
            Disparar();
            ReiniciarTemporizador();
        }
    }

    void Disparar()
    {
        if (prefabBurbuja == null) return;

        Vector3 posicionSalida = (puntoDisparo != null) ? puntoDisparo.position : transform.position;
        Instantiate(prefabBurbuja, posicionSalida, Quaternion.identity);
    }

    void ReiniciarTemporizador()
    {
        temporizador = Random.Range(intervaloMinimo, intervaloMaximo);
    }
}


