// Jone Sainz Egea
// 31/07/2025
    // Singleton structure
// 02/08/2025
    // Game over added

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject scoreboardPanel;
    [SerializeField] private TMP_Text latestScoreText;
    [SerializeField] private ScoreboardUI scoreboardUI;

    private int latestScore;

    public static event Action OnRetry;
    public static event Action OnGameOver;

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
        scoreboardPanel.SetActive(false);
    }

    public void GameOver(int score)
    {
        OnGameOver?.Invoke();
        latestScore = score;
        StartCoroutine(GameOverCoroutine());
    }

    public void Retry()
    {
        gameOverPanel.SetActive(false);
        scoreboardPanel.SetActive(false);
        Time.timeScale = 1;
        OnRetry?.Invoke();
    }

    public void OpenScoreboard()
    {
        scoreboardUI.GetLatestScore(latestScore);
        scoreboardPanel.SetActive(true);
    }

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(0.7f);
        Time.timeScale = 0;
        latestScoreText.text = "Score: " + latestScore;
        gameOverPanel.SetActive(true);
    }
}
