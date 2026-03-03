using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    
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
            Destroy(gameObject); // destroy laser
            Destroy(other.gameObject); // destroy enemy
        }
    }
}
