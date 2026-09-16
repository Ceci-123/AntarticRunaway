using UnityEngine;

public class EnemigoBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si lo que tocó al enemigo tiene el script HieloBehaviour o el tag Hielo
        if (collision.GetComponent<HieloBehaviour>() != null || collision.CompareTag("Hielito"))
        {
            // Destruir el hielo que impactó
            Destroy(collision.gameObject);

            // Destruir al enemigo
            Destroy(gameObject);
        }
    }
}