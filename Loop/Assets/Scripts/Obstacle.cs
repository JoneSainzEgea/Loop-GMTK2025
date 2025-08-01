// Jone Sainz Egea
// 31/07/2025
// Obstacle object

using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //public Vector2 initialPosSprite { get; private set; }
    //public Vector2 finalPosSprite { get; private set; }
    public SpriteCurve curve {  get; private set; }
    public Vector2 initialPosCollider { get; private set; }
    public float duration { get; private set; } = 5f;

    public Obstacle(SpriteCurve curve, Vector2 initialPosCollider, float duration)
    {
        //this.initialPosSprite = initialPosSprite;
        //this.finalPosSprite = finalPosSprite;
        this.curve = curve;
        this.initialPosCollider = initialPosCollider;
        this.duration = duration;
    }
}
