/**
 * * @Project Antartic Runaway
 * @fileoverview Clase burbuja behaviour.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-10-01 11:49
 * @lastModified 2026-10-01 11:49
 * @lastModifiedBy Ceci
 * 
 * Copyright (c) 2026 - Todos los derechos reservados.
 */
using UnityEngine;

public class BurbujaBehaviour : MonoBehaviour
{
    [Header("Configuración de la Burbuja")]
    public float velocidad = 3f;
    public float tiempoVida = 5f;

    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        transform.position += Vector3.down * velocidad * Time.deltaTime;
    }
}
