/**
 * * @Project Antartic Runaway
 * @fileoverview Clase burbuja behaviour, se encarga del comportamiento de las burbujas.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-10-01 11:49
 * @lastModified 2026-10-02 14:44
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

    /// <summary>
    /// Cuando detecta la colision confirma por el tag que toco al pinguino 
    /// llama al metodo que elimina una vida y elimina la burbuja
    /// </summary>
    /// <param>No recibe parámetros.</param>
    /// <returns>No devuelve ningún valor (void).</returns>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Jugador")
        {
            Debug.Log("Tag: " + other.tag + " | ¿Tiene VidasJugador?: " + (other.GetComponent<VidasJugador>() != null));
        }
        
        if (other.CompareTag("Jugador"))
        {
            VidasJugador vidas = other.GetComponent<VidasJugador>();
            if (vidas != null)
            {
                vidas.RecibirDanio();
            }
            Destroy(gameObject);
        }
    }
}
