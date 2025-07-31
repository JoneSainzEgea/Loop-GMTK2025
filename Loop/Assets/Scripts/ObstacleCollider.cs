using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float duration;
    private float timer = 0f;

    public void Initialize(Obstacle data)
    {
        startPosition = transform.position;

        // Define un destino horizontal fuera de pantalla (ajústalo según tu juego)
        endPosition = startPosition + Vector2.up * 10f;

        float distance = Vector3.Distance(startPosition, endPosition);
        duration = distance / data.speed;
    }

    void Update()
    {
        if (duration <= 0) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);
        transform.position = Vector3.Lerp(startPosition, endPosition, t);

        if (t >= 1f)
        {
            Destroy(transform.root.gameObject); // Destruye todo el obstáculo cuando termina
        }
    }
}
