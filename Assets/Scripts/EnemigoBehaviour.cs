using UnityEngine;
using static UnityEditor.ShaderData;

public class EnemigoBehaviour : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidad = 2f;
    public float distanciaMovimiento = 2f;

    private Vector3 posicionInicial;
    private float desfaseTiempo; // Offset aleatorio para desincronizar

    void Start()
    {
        // Guardamos la posición inicial donde apareció la ballena
        posicionInicial = transform.position;
        // Generamos un número aleatorio entre 0 y 10 para cada ballena
        desfaseTiempo = Random.Range(0f, 10f);
        // Variar un poco la velocidad para que una vaya más rápido que otra
        velocidad += Random.Range(-0.5f, 0.5f);
    }

    void Update()
    {
        float desplazamientoX = Mathf.Sin((Time.time + desfaseTiempo) * velocidad) * distanciaMovimiento;
        transform.position = posicionInicial + new Vector3(desplazamientoX, 0f, 0f);
    }
}

    //private void OnTriggerEnter2D(Collider2D collision)
    
        // Verificar si lo que tocó al enemigo tiene el script HieloBehaviour o el tag Hielo
       // if (collision.GetComponent<HieloBehaviour>() != null || collision.CompareTag("Hielito"))
        //{
            // Destruir el hielo que impactó
          //  Destroy(collision.gameObject);

            // Destruir al enemigo
            //Destroy(gameObject);
        