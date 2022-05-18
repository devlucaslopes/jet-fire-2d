using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesPlatform : MonoBehaviour
{
    public GameObject enemyPrefab;

    public List<Transform> points = new List<Transform>();

    private GameObject currentEnemy;

    public float enemySpawnRatio;
    float currentEnemySpawnRation;

    void Start()
    {
        currentEnemySpawnRation = enemySpawnRatio;
        CreateEnemy();
    }

    public void Spawn()
    {
        if (currentEnemy == null)
        {
            CreateEnemy();
        }
    }

    bool ShouldSpawnEnemy()
    {
        float ratio = Random.Range(0.0f, 1.0f);

        return currentEnemySpawnRation >= ratio;
    }

    void CreateEnemy()
    {
        bool shouldSpawn = ShouldSpawnEnemy();

        if (shouldSpawn)
        {
            int pointIndex = Random.Range(0, points.Count);

            GameObject enemy = Instantiate(enemyPrefab, points[pointIndex].position, points[pointIndex].rotation);

            enemy.transform.parent = points[pointIndex].transform;

            currentEnemy = enemy;
        }

        if (currentEnemySpawnRation < 1) {
            currentEnemySpawnRation += 0.1f;
        }
    }
}
