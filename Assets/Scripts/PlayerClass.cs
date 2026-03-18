using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
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
    // Player Stats (This would technically be the ship... not sure how to separate from combat stats yet)
    public int health;
    public int firerate;
    public int laserDamage;
    public int speed;

    // when player collides with prism/crystal, crystal is destroyed and player stats are upgraded
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Prism"))
        {
            // destroy the crystal object
            Destroy(other.gameObject);
            if (audioManager != null && audioManager.prismPickup != null)
            {
                audioManager.PlaySFX(audioManager.prismPickup); //Calls audio for cystal collect
            }
            // upgrade player stats here 
            health += 1;
            firerate += 1;
            laserDamage += 1;
            speed += 1;
            Debug.Log("Player collected a crystal! Stats upgraded.");
        }
    }

}
