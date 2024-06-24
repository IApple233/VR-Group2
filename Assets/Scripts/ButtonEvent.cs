using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credit()
    {
        SceneManager.LoadScene("Producer");
    }

    public void Rule()
    {
        SceneManager.LoadScene("Rule");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Score()
    {
        SceneManager.LoadScene("Score");
    }
}
