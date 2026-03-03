using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // define vars
    [SerializeField] GameObject BaseEnemy;  
    [SerializeField] int enemiesToSpawn = 10; // how many enemies to spawn in total. this is the "variant" that changes per level
    [SerializeField] float spawnInterval = 1f; // seconds between spawns
    [SerializeField] float spawnRangeX = 8f; // horizontal range for spawning

    int spawnedCount = 0; // how many enemies have been spawned so far
    float timer = 0f; // timer to track time since last spawn

    // Update is called once per frame
    void Update()
    {
        if (spawnedCount >= enemiesToSpawn)
        {
            return; // stop spawning if we've reached the limit
        }

        timer += Time.deltaTime; // increment timer by time since last frame

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f; // reset timer after spawning
        }
    }

    void SpawnEnemy()
    {
        // check if enemy prefab is assigned
        if (BaseEnemy == null)
        {
            Debug.LogError("EnemySpawner: BaseEnemy is NULL!");
            return;
        }

        float randomX = Random.Range(-spawnRangeX, spawnRangeX); // get random x position
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f); // spawn at this position
        Instantiate(BaseEnemy, spawnPosition, Quaternion.identity); // create enemy
        spawnedCount++; // increment count of spawned enemies
    }

    
}
