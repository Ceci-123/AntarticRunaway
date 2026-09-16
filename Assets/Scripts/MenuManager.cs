using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Paneles de la UI")]
    public GameObject panelPortada;
    public GameObject panelCreditos;

    void Start()
    {
        // Aseguramos el estado inicial al presionar Play
        MostrarPortada();
    }

    public void MostrarCreditos()
    {
        panelPortada.SetActive(false);
        panelCreditos.SetActive(true);
    }

    public void MostrarPortada()
    {
        panelPortada.SetActive(true);
        panelCreditos.SetActive(false);
    }
}