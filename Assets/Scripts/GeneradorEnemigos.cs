/**
 * * @Project Antartic Runaway
 * @fileoverview Clase para gestionar la generacion de enemigos.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-09-30 14:35
 * @lastModified 2026-09-30 14:35
 * @lastModifiedBy Ceci
 * 
 * Copyright (c) 2026 - Todos los derechos reservados.
 */
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    [Header("Configuración del Enemigo")]
    public GameObject prefabBallena;
    public int cantidadEnemigos = 3;

    [Header("Límites de Posición (Eje X)")]
    public float xMinima = -6f;
    public float xMaxima = 6f;

    [Header("Límites de Posición (Eje Y)")]
    public float yMinima = 2f; 
    public float yMaxima = 4f;

    void Start()
    {
        GenerarEnemigos();
    }

    /// <summary>
    /// Calcula posiciones aleatorias respetando los limites de la pantalla e instancia un enemigo en la posicion calculada.
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    void GenerarEnemigos()
    {
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            float posXAleatoria = Random.Range(xMinima, xMaxima);
            float posYAleatoria = Random.Range(yMinima, yMaxima);
            Vector3 posicionAleatoria = new Vector3(posXAleatoria, posYAleatoria, 0f);
            Instantiate(prefabBallena, posicionAleatoria, Quaternion.identity);

            if (GameManager.Instance != null)
            {
                GameManager.Instance.RegistrarEnemigo();
            }
        }

        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.FinalizarGeneracion();
        }
    }
}
