// Jone Sainz Egea
// 02/08/2025

using UnityEngine;

[System.Serializable]
public class DifficultyLevel
{
    [Header("Obstacles")]
    public float minSpawnInterval = 2f;
    public float maxSpawnInterval = 2f;
    public float obstacleSpeed = 5f;

    [Header("Visuals")]
    public float stairsAnimationSpeed = 1f;
    public float characterAnimationSpeed = 1f;

    [Header("Score")]
    public float scoreMultiplier = 1;
}
