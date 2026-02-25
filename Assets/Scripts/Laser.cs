using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * speed;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
