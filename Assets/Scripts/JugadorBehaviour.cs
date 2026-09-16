using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidad = 5f; 

    [Header("Límites de Pantalla (Eje X)")]
    public float limiteIzquierdo = -8f;
    public float limiteDerecho = 8f;

    [Header("Configuración de Disparo")]
    public GameObject prefabHielo; // Asignar el prefab desde el Inspector
    public Transform puntoDisparo;  // Punto desde donde sale el hielo

    void Start()
    {
        float mitadAltura = Camera.main.orthographicSize;
        float mitadAncho = mitadAltura * Camera.main.aspect;

        limiteIzquierdo = -mitadAncho + 0.5f; // 0.5f de margen, ajustable
        limiteDerecho = mitadAncho - 0.5f;
    }
    void Update()
    {
        // Obtener la entrada del teclado (flecha izquierda / derecha o A / D)
        float entradaHorizontal = Input.GetAxisRaw("Horizontal");

        // Mover en el espacio del mundo 2D usando transform
        Vector3 nuevaPosicion = transform.position + new Vector3(entradaHorizontal * velocidad * Time.deltaTime, 0, 0);

        // Limitar la posición horizontal en unidades del mundo
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, limiteIzquierdo, limiteDerecho);

        // Aplicar la nueva posición
        transform.position = nuevaPosicion;

        // Detectar la barra espaciadora para disparar
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            DispararHielo();
        }
    }

    void DispararHielo()
    {
        if (prefabHielo == null) return;

        // Determinar el punto de origen del disparo
        Vector3 posicionSalida = (puntoDisparo != null) ? puntoDisparo.position : transform.position;

        // Instanciar el proyectil en el mundo 2D 
        Instantiate(prefabHielo, posicionSalida, Quaternion.identity);
    }
}