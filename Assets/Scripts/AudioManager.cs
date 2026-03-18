using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [Header("----------Audio Source ----------")]
   [SerializeField] AudioSource musicSource;
   [SerializeField] AudioSource SFXSource;

   [Header("----------Audio Clip ----------")]
   public AudioClip background;
   public AudioClip enemyDestoryed;
   public AudioClip playerDeath;
   public AudioClip prismPickup;
   public AudioClip shoot;
   
   


   private void Start()
   {
      musicSource.clip = background;
      musicSource.Play();
   }

   public void PlaySFX(AudioClip clip)
      public void PlaySFX(AudioClip clip)
      {
         if (SFXSource != null)
         {
      SFXSource.PlayOneShot(clip);
         }
      }
   }


}
