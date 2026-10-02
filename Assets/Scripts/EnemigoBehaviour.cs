/**
 * * @Project Antartic Runaway
 * @fileoverview Clase para el manejo de comportamiento de enemigos.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-09-30 14:35
 * @lastModified 2026-09-30 14:35
 * @lastModifiedBy Ceci
 * 
 * Copyright (c) 2026 - Todos los derechos reservados.
 */
using UnityEngine;
using static UnityEditor.ShaderData;

public class EnemigoBehaviour : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidad = 2f;
    public float distanciaMovimiento = 2f;

    private Vector3 posicionInicial;
    private float desfaseTiempo; 

    void Start()
    {
        posicionInicial = transform.position;
        desfaseTiempo = Random.Range(0f, 10f);
        velocidad += Random.Range(-0.5f, 0.5f);
    }

    void Update()
    {
        float desplazamientoX = Mathf.Sin((Time.time + desfaseTiempo) * velocidad) * distanciaMovimiento;
        transform.position = posicionInicial + new Vector3(desplazamientoX, 0f, 0f);
    }
}

    
        