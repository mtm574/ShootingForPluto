using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject BaseEnemy;  
    [SerializeField] int enemiesToSpawn = 10; // total enemies to spawn
    [SerializeField] float spawnInterval = 1f; // seconds between spawns
    [SerializeField] float spawnRangeX = 8f; // horizontal range

    int spawnedCount = 0; // how many enemies have been spawned
    float timer = 0f; // timer since last spawn

    void Update()
    {
        if (spawnedCount >= enemiesToSpawn)
            return; // done spawning

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (BaseEnemy == null)
        {
            Debug.LogError("EnemySpawner: BaseEnemy is NULL!");
            return;
        }

        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);
        Instantiate(BaseEnemy, spawnPosition, Quaternion.identity);
        spawnedCount++;
    }

    // **Added method for LevelManager**
    public bool IsFinishedSpawning()
    {
        return spawnedCount >= enemiesToSpawn;
    }
}