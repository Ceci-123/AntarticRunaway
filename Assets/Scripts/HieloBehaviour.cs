using UnityEngine;

public class HieloBehaviour : MonoBehaviour
{
    [Header("Configuración del Proyectil")]
    public float velocidad = 800f; // Velocidad con la que sube el hielo
    public float tiempoVida = 3f;   // Segundos antes de destruirse si no choca

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        // Autodestruir el hielo después de n segundos para no saturar la memoria
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        // Mover el hielo hacia arriba verticalmente
        rectTransform.anchoredPosition += new Vector2(0, velocidad * Time.deltaTime);
    }
}
