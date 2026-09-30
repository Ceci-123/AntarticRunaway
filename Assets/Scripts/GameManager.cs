/**
 * * @Project Antartic Runaway
 * @fileoverview Clase game manager.
 * @author Ceci <ceciliacalanna@gmail.com>
 * @created 2026-09-30 15:39
 * @lastModified 2026-09-30 15:39
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

    private int totalEnemies;

    private void Awake()
    {
        // Patron Singleton simple para acceder facil desde los enemigos
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
        // Ocultamos el cartel por seguridad al iniciar
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Busca todos los enemigos en la escena con el Tag "Enemy"
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemigo").Length;
    }

    public void OnEnemyKilled()
    {
        totalEnemies--;

        if (totalEnemies <= 0)
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

        // Opcional: Pausar el juego al morir todos
        // Time.timeScale = 0f;
    }
}
