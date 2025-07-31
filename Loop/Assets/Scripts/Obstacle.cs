// Jone Sainz Egea
// 31/07/2025

public class Obstacle
{
    private int position;
    public float speed { get; private set; } = 5f;

    public Obstacle(int position, float speed)
    {
        this.position = position;
        this.speed = speed;
    }
}
