using UnityEngine;

public class Crystal : MonoBehaviour
{
    public float lifetime = 3f;
    public AudioClip collectSFX; // optional sound
    private AudioSource audioSource;

    void Start()
    {
        // Destroy the crystal automatically after lifetime
        Destroy(gameObject, lifetime);

        // Find AudioSource in scene
        audioSource = FindObjectOfType<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Play sound if available
            if (collectSFX != null && audioSource != null)
                audioSource.PlayOneShot(collectSFX);

            // Add crystal to player inventory
            PlayerInventory playerInv = collision.GetComponent<PlayerInventory>();
            if (playerInv != null)
                playerInv.AddCrystal(1);

            // Destroy the crystal
            Destroy(gameObject);
        }
    }
}