using UnityEngine;

public class Enemy : MonoBehaviour
{
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
}
