// Jone Sainz Egea
// 02/08/2025
// Setting of difficulty levels

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficulyManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenDifficulties = 30f;
    [SerializeField] private List<DifficultyLevel> difficultyLevels = new List<DifficultyLevel>();

    private int currentLevelIndex = 0;
    public DifficultyLevel CurrentDifficulty => difficultyLevels[currentLevelIndex];

    private void Start()
    {
        ApplyDifficulty();
        StartCoroutine(DifficultyProgression());
    }

    private IEnumerator DifficultyProgression()
    {
        while (currentLevelIndex < difficultyLevels.Count - 1)
        {
            yield return new WaitForSeconds(timeBetweenDifficulties);
            IncreaseDifficulty();
        }
    }

    public void IncreaseDifficulty()
    {
        if (currentLevelIndex < difficultyLevels.Count - 1)
        {
            currentLevelIndex++;
            ApplyDifficulty();
        }
    }

    private void ApplyDifficulty()
    {
        DifficultyLevel level = CurrentDifficulty;

        ObstacleManager.instance.SetSpawnInterval(level.minSpawnInterval, level.maxSpawnInterval);
        ObstacleManager.instance.SetObstacleSpeed(level.obstacleSpeed);

        // TODO: AnimationManager.instance.SetGlobalAnimationSpeed(level.animationSpeed);

        ScoreManager.instance.SetScoreMultiplier(level.scoreMultiplier);
    }
}
