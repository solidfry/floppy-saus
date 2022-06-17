using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject parentObject;
    // * This will house the various obstacles that can be randomly spawned.
    public List<GameObject> obstaclePrefabs;

    [SerializeField]
    private int minSpawnAmount, maxSpawnAmount;

    private void OnEnable()
    {
        GameEvents.OnDestroyObstaclesEvent += DestroyObstacles;
        GameEvents.OnSpawnObstaclesEvent += SpawnObstacles;
    }

    private void OnDisable()
    {
        GameEvents.OnDestroyObstaclesEvent -= DestroyObstacles;
        GameEvents.OnSpawnObstaclesEvent -= SpawnObstacles;
    }

    void SpawnObstacles()
    {
        Debug.Log("Spawn Obstacles");
        foreach (GameObject obstacle in obstaclePrefabs)
        {
            int amountToSpawn = Random.Range(minSpawnAmount, maxSpawnAmount);
            Debug.Log(amountToSpawn);
            for (int i = 0; i < amountToSpawn; i++)
            {
                Vector3 randomPosition = new Vector3(Random.Range(Boundaries.hBounds.x, Boundaries.hBounds.y), Random.Range(Boundaries.vBounds.x, Boundaries.vBounds.y), 0);
                // Debug.Log(obstacle + "generated");
                GameObject newObstacle = Instantiate(obstacle.gameObject, randomPosition, Quaternion.identity) as GameObject;
                newObstacle.transform.parent = parentObject.transform;
            }
        }
    }

    void DestroyObstacles()
    {
        foreach (Transform child in parentObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }


}
