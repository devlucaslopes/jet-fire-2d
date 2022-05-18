using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeals : MonoBehaviour
{
    public GameObject HealPrefab;

    private float timeCount;
    public float spawnTime;

    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount >= spawnTime)
        {
            Spawn();
            timeCount = 0;
        }
    }

    void Spawn()
    {
        Instantiate(HealPrefab, transform.position + new Vector3(0f, Random.Range(0f, -1f), 0), transform.rotation);
    }
}
