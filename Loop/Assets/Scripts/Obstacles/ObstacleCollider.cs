// Jone Sainz Egea
// 01/08/2025
    // Simulates obstacle collider trajectory

using System;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 endPosition;
    [SerializeField] private float distanceUp;

    private float duration;
    private float timer = 0f;

    public static event Action OnPlayerHit;

    public void Initialize(Obstacle data)
    {
        startPosition = data.initialPosCollider;
        endPosition = startPosition + Vector2.up * distanceUp;

        duration = data.duration;
    }

    void Update()
    {
        if (duration <= 0) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);

        transform.position = Vector3.Lerp(startPosition, endPosition, t);

        if (t >= 1f)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player")))
        {
            OnPlayerHit?.Invoke();
            ScoreManager.instance.SubstractHearts();
            ScoreManager.instance.SubtractPoints(20f);
        }
    }
}
