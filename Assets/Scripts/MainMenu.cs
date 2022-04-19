using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string nextScene;
    [SerializeField] TextMeshProUGUI highScoreText;

    void Start()
    {
        if (PlayerPrefs.HasKey("High Score"))
            highScoreText.text = $"High Score: {PlayerPrefs.GetInt("High Score")}"; ;
    }

    public void NextScene()
    {
        SetHighScore();
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Game Round");
        SceneManager.LoadScene(nextScene);
        if (ThemeMusic.instance != null)
            ThemeMusic.instance.gameObject.SetActive(true);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Game Round");
        Application.Quit();
    }

    // Possible display high score to be competitive at game over screen
    public void SetHighScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            int newHighScore = PlayerPrefs.GetInt("Score");
            if (newHighScore > PlayerPrefs.GetInt("High Score"))
            {
                PlayerPrefs.SetInt("High Score", newHighScore);
                highScoreText.text = $"High Score: {PlayerPrefs.GetInt("High Score")}"; ;
            }
        }
    }
}
