// Jone Sainz Egea
// 31/07/2025
    // Simulates obstacle trajectory

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSprite : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Vector2 initialScale;
    private Vector2 finalScale;

    private float duration;
    private float timer = 0f;

    public void Initialize(Obstacle data)
    {
        startPosition = data.initialObjectPosition;
        endPosition = data.finalObjectPosition;
        duration = data.duration;

        finalScale = transform.localScale;
        initialScale = transform.localScale/10f;
    }

    void Update()
    {
        if (duration <= 0) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);
        transform.position = Vector3.Lerp(startPosition, endPosition, t);
        transform.localScale = Vector3.Lerp(initialScale, finalScale, t);

        if (t >= 1f)
        {
            Destroy(transform.root.gameObject); // Destruye todo el obstáculo cuando termina
        }
    }
}
