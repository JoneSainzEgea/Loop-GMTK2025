// Jone Sainz Egea
// 31/07/2025
// Obstacle object

using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector2 initialObjectPosition { get; private set; }
    public Vector2 finalObjectPosition { get; private set; }
    public Vector2 initialColliderPosition { get; private set; }
    public float duration { get; private set; } = 5f;

    public Obstacle(Vector2 initialObjPos, Vector2 finalObjPos, Vector2 initialColPos, float duration)
    {
        initialObjectPosition = initialObjPos;
        finalObjectPosition = finalObjPos;
        initialColliderPosition = initialColPos;
        this.duration = duration;
    }
}
