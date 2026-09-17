using UnityEngine;

public class HieloBehaviour : MonoBehaviour
{
    [Header("Configuración del Proyectil")]
    public float velocidad = 3f; // Velocidad con la que sube el hielo
    public float tiempoVida = 3f;   // Segundos antes de destruirse si no choca

    
    void Start()
    {
        // Autodestruir el hielo después de n segundos para no saturar la memoria
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        // Mueve el hielo hacia arriba en coordenadas de mundo
        transform.position += Vector3.up * velocidad * Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Destroy(other.gameObject); // destruye al enemigo
            Destroy(gameObject);       // destruye el hielito
        }
    }
}
