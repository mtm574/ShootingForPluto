using UnityEngine;

public class Enemy : MonoBehaviour
{
    AudioManager audioManager;
    public int health = 1; // default health for an enemy
    public GameObject crystalPrefab; // reference to the crystal prefab to drop on death

    // Add reference to LevelManager
    private LevelManager levelManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        // Find LevelManager in scene
        levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            // Optional: increment enemy count if using the notified approach
            levelManager.enemiesRemaining++;
        }
    }

    void OnBecameInvisible()
    {
        // If you want invisible enemies to count as defeated:
        Die();
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        // Notify LevelManager BEFORE destroying
        if (levelManager != null)
            levelManager.EnemyDefeated();

        // Play audio and destroy enemy
        Destroy(gameObject);
        audioManager.PlaySFX(audioManager.enemyDestoryed);

        // Drop crystal
        if (crystalPrefab != null)
            Instantiate(crystalPrefab, transform.position, Quaternion.identity);
    }
}