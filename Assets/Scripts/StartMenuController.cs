using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
   public void OnStartClick()
    {
        SceneManager.LoadScene("ShootingForPluto");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
