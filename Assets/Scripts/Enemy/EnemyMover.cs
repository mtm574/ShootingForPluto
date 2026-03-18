using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Vector2 direction = Vector2.down; // default

    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}