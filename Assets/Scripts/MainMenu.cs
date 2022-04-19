using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string nextScene;

    public void NextScene()
    {
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
    void SetHighScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            int newHighScore = PlayerPrefs.GetInt("Score");
            if (newHighScore > PlayerPrefs.GetInt("High Score"))
            {

            }
        }
    }
}
