using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void endGame()
    {
        Application.Quit();
        Debug.LogWarning("Quitting");
    }
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1f;
        Debug.LogWarning("Reloading scene...");
    }
}
