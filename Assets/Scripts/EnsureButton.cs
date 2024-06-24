using UnityEngine;
using UnityEngine.UI;

public class EnsureButton : MonoBehaviour
{
    public GameObject FunctionButton;
    public GameObject ScoreButton;
    public GameManager GameManager;
    public Text UserName;
    public Text Score;

    public void EnableFuncion()
    {
        if (UserName.text != "")
        {
            GameManager.Record(UserName.text, Score.text.Substring(0, Score.text.Length - 1));
            FunctionButton.SetActive(true);
            ScoreButton.SetActive(false);
        }
    }
}
