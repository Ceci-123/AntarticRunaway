/**
 * * @Project Antartic Runaway
 * @fileoverview Clase de comportamiento del proyectil.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-09-30 14:35
 * @lastModified 2026-09-30 14:35
 * @lastModifiedBy Ceci
 * 
 * Copyright (c) 2026 - Todos los derechos reservados.
 */
using UnityEngine;

public class HieloBehaviour : MonoBehaviour
{
    [Header("Configuración del Proyectil")]
    public float velocidad = 3f; 
    public float tiempoVida = 3f;  

    
    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
       transform.position += Vector3.up * velocidad * Time.deltaTime;

    }

    /// <summary>
    /// Cuando detecta la colision destruye el enemigo y destruye el proyectil.
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnEnemyKilled();
                Debug.Log("llamo al script de game manager");
            }
            Destroy(other.gameObject); 
            Destroy(gameObject);       
        }
    }
}
