using UnityEngine;
using UnityEngine.SceneManagement; // For scene transitions

public class LevelManager : MonoBehaviour
{
    public int enemiesRemaining;
    public EnemySpawner spawner; // assign your EnemySpawner in the Inspector

    void Start()
    {
        // enemiesRemaining is set by Enemy objects on spawn
        if (spawner == null)
            Debug.LogWarning("LevelManager: EnemySpawner not assigned!");
    }

    public void EnemyDefeated()
    {
        enemiesRemaining--;
        Debug.Log("Enemy defeated! Remaining: " + enemiesRemaining);

        // Only complete level if no enemies remain AND spawner finished
        if (enemiesRemaining <= 0 && spawner != null && spawner.IsFinishedSpawning())
        {
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        Debug.Log("Level Complete!");
        // Trigger next level or UI
        // im not sure how to make this dynamic 
        SceneManager.LoadScene("Shop 1"); 
    }
}