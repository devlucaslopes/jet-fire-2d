using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> enemiesList = new List<GameObject>();

    private float timeCount;
    public float spawnTime;

    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount >= spawnTime)
        {
            SpawnEnemy();
            timeCount = 0;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], transform.position + new Vector3(0f, Random.Range(-0.5f, 1f), 0), transform.rotation);
    }
}
