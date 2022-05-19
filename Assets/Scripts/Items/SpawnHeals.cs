using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeals : MonoBehaviour
{
    public GameObject HealPrefab;

    private float timeCount;
    public float spawnTime;
    private float baseTimeToSpawn;

    private void Start()
    {
        baseTimeToSpawn = spawnTime;    
    }

    void Update()
    {
        if (Time.time >= 15)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= spawnTime)
            {
                Spawn();
                timeCount = 0;
                spawnTime = Random.Range(baseTimeToSpawn - 5, baseTimeToSpawn);
            }
        }


    }

    void Spawn()
    {
        Instantiate(HealPrefab, transform.position + new Vector3(0f, Random.Range(0f, -1f), 0), transform.rotation);
    }
}
