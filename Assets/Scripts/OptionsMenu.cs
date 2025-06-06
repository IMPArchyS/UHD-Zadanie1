using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    private RectTransform bg;

    [SerializeField]
    private TextMeshProUGUI screenText;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    private void Start()
    {
        bg = GetComponent<RectTransform>();
    }
    private void Update()
    {
    }
    public void endGame()
    {
        Application.Quit();
        Debug.LogWarning("Quitting");
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Debug.LogWarning("Reloading scene...");
    }
    public void getPoints()
    {
        scoreText.SetText("score:" + GameManager.getPoints().ToString());
    }
    public void setScreenText(string s)
    {
        screenText.SetText(s);
    }

    public RectTransform getBG()
    {
        return bg;
    }
}
