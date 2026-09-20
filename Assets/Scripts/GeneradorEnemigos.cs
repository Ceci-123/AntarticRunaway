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
    public float yMinima = 2f; // Garantiza que no queden muy abajo
    public float yMaxima = 4f;

    void Start()
    {
        GenerarEnemigos();
    }

    void GenerarEnemigos()
    {
        if (prefabBallena == null)
        {
            Debug.LogError("OMG OMG OMG ¡No asignaste el Prefab de la ballena en el inspector!");
            return;
        }

        for (int i = 0; i < cantidadEnemigos; i++)
        {
            // Calculamos posiciones aleatorias en X e Y respetando los límites
            float posXAleatoria = Random.Range(xMinima, xMaxima);
            float posYAleatoria = Random.Range(yMinima, yMaxima);

            Vector3 posicionAleatoria = new Vector3(posXAleatoria, posYAleatoria, 0f);

            // Instanciamos la ballena en la posición calculada
            Instantiate(prefabBallena, posicionAleatoria, Quaternion.identity);
        }
    }
}
