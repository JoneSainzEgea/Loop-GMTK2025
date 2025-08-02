// Jone Sainz Egea
// 31/07/2025
    // Singleton structure
// 02/08/2025
    // Game over added

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        gameOverPanel.SetActive(true);
    }
}
