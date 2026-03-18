using UnityEngine;

public class Enemy : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake() // Calls the audio manager
    {
        GameObject audioObj = GameObject.FindGameObjectWithTag("Audio");
        if (audioObj != null)
        {
            audioManager = audioObj.GetComponent<AudioManager>();
        }
        else
        {
            audioManager = null;
        }
    }

    public int health = 1; // default health for an enemy
    public GameObject crystalPrefab; // reference to the crystal prefab to drop on death

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroy the enemy when it goes off-screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

     // Method for taking damage
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    // Destroy enemy
    protected virtual void Die()
    {
        Destroy(gameObject);
        if (audioManager != null && audioManager.enemyDestoryed != null)
        {
            audioManager.PlaySFX(audioManager.enemyDestoryed); //Calls audio for enemy destroyed
        }
        // drop crystal
        Instantiate(crystalPrefab, transform.position, Quaternion.identity);
    }

}
