/**
 * * @Project Antartic Runaway
 * @fileoverview Clase game manager.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-09-30 15:39
 * @lastModified 2026-10-01 11:04
 * @lastModifiedBy Ceci
 * 
 * Copyright (c) 2026 - Todos los derechos reservados.
 */
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Reference")]
    [SerializeField] private GameObject gameOverPanel;

    //private int totalEnemies;
    private int enemigosVivos = 0;
    private bool generacionTerminada = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }


    public void RegistrarEnemigo()
    {
        enemigosVivos++;
    }

    public void FinalizarGeneracion()
    {
        generacionTerminada = true;
        ComprobarFin();
    }

    public void OnEnemyKilled()
    {
        enemigosVivos--;
        Debug.Log("Enemigos vivos: " + enemigosVivos);
        ComprobarFin();
    }
    private void ComprobarFin()
    {
        if (generacionTerminada && enemigosVivos <= 0)
        {
            ShowGameOver();
        }
    }

    private void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

       
        Time.timeScale = 0f;
    }
}
