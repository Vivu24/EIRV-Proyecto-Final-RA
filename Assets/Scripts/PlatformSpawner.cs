using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;
    public float spawnDistance = 10f;
    public float minX = -3f;
    public float maxX = 3f;
    public float minZ = -3f;
    public float maxZ = 3f;
    public float ySpacing = 2f;
    public int initialPlatforms = 3;
    private float lastSpawnY;
    private List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        lastSpawnY = player.position.y;
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform(lastSpawnY + (i * ySpacing));
        }
    }

    void Update()
    {
        if (player.position.y > lastSpawnY - spawnDistance)
        {
            SpawnPlatform(lastSpawnY + ySpacing);
            lastSpawnY += ySpacing;
        }
    }

    void SpawnPlatform(float yPosition)
    {
        float xPosition = Random.Range(minX, maxX);
        float zPosition = Random.Range(minZ, maxZ);
        GameObject newPlatform = Instantiate(platformPrefab, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);
        platforms.Add(newPlatform);
    }
}