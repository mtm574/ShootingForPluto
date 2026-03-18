using UnityEngine;

public class SatelliteSpawner : MonoBehaviour
{
    public GameObject satellitePrefab;
    public int satellitesToSpawn = 5;
    public float spawnInterval = 1f;
    public float spawnRangeX = 8f;

    int spawnedCount = 0;
    float timer = 0f;

    void Update()
    {
        if (spawnedCount >= satellitesToSpawn) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnSatellite();
            timer = 0f;
        }
    }

    void SpawnSatellite()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0f);
        Instantiate(satellitePrefab, spawnPos, Quaternion.identity);
        spawnedCount++;
    }
}