// Jone Sainz Egea
// 31/07/2025
    // Score goes up with time and shows in screen

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float score { get; private set; } = 0f;
    [SerializeField] private float baseIncreaseRate = 1f;
    private float scoreMultiplier = 1f;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Update()
    {
        score += baseIncreaseRate * scoreMultiplier * Time.deltaTime;
        UpdateScoreText();
    }

    public void AddPoints(float amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void SubtractPoints(float amount)
    {
        score -= amount;
        if (score < 0f) score = 0f;
        UpdateScoreText();
    }

    public void IncreaseMultiplier(float amount)
    {
        scoreMultiplier += amount;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {Mathf.FloorToInt(score)}";
        }
    }
}
