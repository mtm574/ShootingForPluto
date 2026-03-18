using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
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

    public int lives = 3; // starting lives
    public Image[] livesUI; // reference to the UI element that displays lives
    public GameObject explosionEffect; // reference to the explosion effect prefab

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // destroy the enemy object
            Destroy(collision.gameObject);

            // Instantiate the explosion effect at the player's position
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

            // Handle player losing a life here
            Debug.Log("Player hit by enemy! Lose a life.");
            lives--;

            // show or hide the UI elements based on remaining lives
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true; // Show remaining lives
                }
                else
                {
                    livesUI[i].enabled = false; // Hide lost lives
                }
            }

            if (lives <= 0)
            {
                Debug.Log("Game Over!");
                Destroy(gameObject); // Destroy the player object 
                audioManager.PlaySFX(audioManager.playerDeath); //Calls audio for player death
            }
        }
    }
}
