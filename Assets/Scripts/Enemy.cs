using UnityEngine;

public class Enemy : MonoBehaviour
{
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
        
        // drop crystal
        Instantiate(crystalPrefab, transform.position, Quaternion.identity);
    }

}
