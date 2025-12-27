using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooling : MonoBehaviour
{
    public static ObstaclePooling instance;
    public GameObject obstaclePrefab;
    [SerializeField] private int maxObstacles;

    private List<GameObject> obstacles;

    private void OnEnable()
    {
        GameManager.OnRetry += ClearObstacles;
    }
    private void OnDisable()
    {
        GameManager.OnRetry -= ClearObstacles;
    }

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


        obstacles = new List<GameObject>(maxObstacles);

        for (int i = 0; i < maxObstacles; i++)
        {
            GameObject prefabInstance = Instantiate(obstaclePrefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);
            obstacles.Add(prefabInstance);
        }
    }

    public GameObject GetObstacle()
    {
        int totalObstacles = obstacles.Count;

        for (int i = 0; i < totalObstacles; i++)
        {
            if (!obstacles[i].activeInHierarchy)
            {
                obstacles[i].SetActive(true);
                return obstacles[i];
            }
        }
        Debug.LogWarning("Couldn't spawn new obstacle because it's outside pooling limits");
        return null;
    }

    public void ClearObstacles()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeInHierarchy)
            {
                obstacles[i].SetActive(false);
                Debug.Log("Deactivated obstacle");
            }
        }
    }
}
