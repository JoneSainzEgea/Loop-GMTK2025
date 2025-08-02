// Jone Sainz Egea
// 01/08/2025
    // Handles obstacle spawning

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager instance;

    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float obstacleSpeed = 5f;
    [SerializeField] private float obstacleDistance = 7f;
    [SerializeField] private SpriteCurve[] curves;
    [SerializeField] private Transform[] startPositionsCollider;

    private float obstacleDuration;
    private float spawnInterval;
    private float minSpawnInterval = 5f;
    private float maxSpawnInterval = 7f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnObstacle();
            spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObstacle()
    {
        int i = Random.Range(0, 3);
        obstacleDuration = obstacleDistance/obstacleSpeed;

        GameObject obj = Instantiate(obstaclePrefab, new Vector3(12f, 0f, 0f), Quaternion.identity);

        Obstacle data = new Obstacle(curves[i], startPositionsCollider[i].position, obstacleDuration);

        ObstacleCollider collider = obj.GetComponentInChildren<ObstacleCollider>();
            collider.Initialize(data);

        ObstacleSprite movement = obj.GetComponentInChildren<ObstacleSprite>();
            movement.Initialize(data);
    }

    public void SetSpawnInterval(float minInterval, float maxInterval)
    {
        minSpawnInterval = minInterval;
        maxSpawnInterval = maxInterval;
    }

    public void SetObstacleSpeed(float speed)
    {
        obstacleSpeed = speed;
    }
}
