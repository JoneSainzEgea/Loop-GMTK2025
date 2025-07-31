using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public float obstacleSpeed = 5f;
    public Transform[] spawnPoints;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPos = spawnPoints[index].position;

        GameObject obj = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

        Obstacle data = new Obstacle(index, obstacleSpeed);

        ObstacleCollider collider = obj.GetComponentInChildren<ObstacleCollider>();
            collider.Initialize(data);
    }
}
