using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlaform : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();

    private List<Transform> currentPlatforms = new List<Transform>();

    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex = 0;

    public float offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < platforms.Count; i++)
        {
            GameObject prefab = platforms[i];

            float yAxios = PlatformYAxis(prefab.tag);

            Transform p = Instantiate(prefab, new Vector2(i * 30f, yAxios), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += 30f;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }

    void Update()
    {
        Move();
    }

    float PlatformYAxis(string tag)
    {
        if (tag == "Fly Platform")
        {
            return -2f;
        }

        return -4f;
    }

    void Move()
    {
        float distance = player.position.x - currentPlatformPoint.position.x;

        if (distance >= 1)
        {
            Recycle(currentPlatforms[platformIndex].gameObject);

            platformIndex++;
            
            if (platformIndex > currentPlatforms.Count - 1)
            {
                platformIndex = 0;
            }

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
        }
    }

    public void Recycle(GameObject platform)
    {
        float yAxios = PlatformYAxis(platform.tag);

        platform.transform.position = new Vector2(offset, yAxios);

        if (platform.GetComponent<Platform>().spawnObj != null)
        {
            platform.GetComponent<Platform>().spawnObj.Spawn();
        }

        offset += 30;
    }
}
