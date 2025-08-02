// Jone Sainz Egea
// 31/07/2025
    // Simulates obstacle trajectory

using UnityEngine;

public class ObstacleSprite : MonoBehaviour
{
    private SpriteCurve curve;
    
    private Vector2 initialScale;
    private Vector2 finalScale;

    private float duration;
    private float timer = 0f;

    public void Initialize(Obstacle data)
    {
        duration = data.duration;
        curve = data.curve;

        finalScale = transform.localScale;
        initialScale = transform.localScale/10f;
    }

    void Update()
    {
        if (duration <= 0) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);

        float x = curve.curveX.Evaluate(t);
        float y = curve.curveY.Evaluate(t);

        transform.position = curve.startPosition + new Vector2(x, y);

        transform.localScale = Vector3.Lerp(initialScale, finalScale, t);

        if (t >= 1f)
        {
            Destroy(transform.root.gameObject);
        }
    }
}
