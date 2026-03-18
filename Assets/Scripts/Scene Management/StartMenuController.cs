using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
   public void OnStartClick()
    {
        SceneManager.LoadScene("Cutscene1");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
