using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifetime = 0.4f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}