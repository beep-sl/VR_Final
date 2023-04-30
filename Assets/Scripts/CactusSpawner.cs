using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CactusSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies;
    public float spawnRadius;
    public float yOffset;

    private void Start()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 randomPoint = Random.insideUnitSphere * spawnRadius;
        randomPoint += transform.position;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, spawnRadius, NavMesh.AllAreas))
        {
            Vector3 finalPosition = hit.position;
            finalPosition.y += yOffset;
            Instantiate(enemyPrefab, finalPosition, Quaternion.identity);
        }
        else
        {
            SpawnEnemy(); // Retry if the random point was not on the NavMesh
        }
    }
}





