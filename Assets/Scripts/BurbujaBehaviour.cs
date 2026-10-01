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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Jugador")
        {
            Debug.Log("Tag: " + other.tag + " | ¿Tiene VidasJugador?: " + (other.GetComponent<VidasJugador>() != null));
        }
        Debug.Log("Burbuja tocó a: " + other.name);
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
