// Jone Sainz Egea
// 01/08/2025
    // Handles obstacle spawning

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float obstacleSpeed = 5f;
    [SerializeField] private float obstacleDistance = 7f;
    [SerializeField] private Transform[] initialPositionsObject;
    [SerializeField] private Transform[] finalPositionsObject;
    [SerializeField] private Transform[] startPositionsCollider;

    private float obstacleDuration;

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
        int i = Random.Range(0, 3); // Randomly spawns between three predefined positions
        obstacleDuration = obstacleDistance/obstacleSpeed;

        GameObject obj = Instantiate(obstaclePrefab, new Vector3(12f, 0f, 0f), Quaternion.identity);

        Obstacle data = new Obstacle(initialPositionsObject[i].position, finalPositionsObject[i].position, startPositionsCollider[i].position, obstacleDuration);

        ObstacleCollider collider = obj.GetComponentInChildren<ObstacleCollider>();
            collider.Initialize(data);

        ObstacleSprite movement = obj.GetComponentInChildren<ObstacleSprite>();
            movement.Initialize(data);
    }
}
