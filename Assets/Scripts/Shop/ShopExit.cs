using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopExit : MonoBehaviour
{
    // Must be public, return void, and take no arguments
    public void GoToNextScene()
    {
        SceneManager.LoadScene("Level2"); // replace with your next scene name
    }
}