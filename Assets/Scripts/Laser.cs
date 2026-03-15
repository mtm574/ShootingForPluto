using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    public GameObject explosionEffect; // reference to the explosion effect prefab
    public int damage = 1; // how much damage this laser does

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * speed;
    }

    // Destroy the laser when it goes off-screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // did we hit an enemy?
        if (other.CompareTag("Enemy"))
        {
            // Tell the enemy to take damage
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Destroy the laser
            Destroy(gameObject);

            // Explosion effect at collision point
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
    }
}