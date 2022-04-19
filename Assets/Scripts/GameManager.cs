using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int gameRounds = 1;
    int humansSavedCount = 0;
    [SerializeField] int maxHumans = 4;
    [SerializeField] int score = 0;

    [SerializeField] GameObject player;
    [HideInInspector] public bool isGameOver = false;
    [SerializeField] TextMeshProUGUI humanSavedText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;

    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;

    public void IncrementHumanSaved()
    {
        humansSavedCount++;
        DisplayHumansSaved();

        if (humansSavedCount == maxHumans)
        {
            PlayerPrefs.SetInt("Game Round", ++gameRounds);
            winUI.SetActive(true);
            isGameOver = true;
            finalScoreText.gameObject.SetActive(finalScoreText);
            player.GetComponent<SphereCollider>().enabled = false;
            player.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(WinningFlight());
        }
    }
    IEnumerator WinningFlight()
    {
        while (true)
        {
            player.transform.Translate(Vector3.right * 8.0f * Time.deltaTime);
            if (player.transform.position.x > 80)
            {
                Destroy(player.gameObject);
                break;
            }
            yield return null;
        }
    }
    public int GetHumanSaved()
    {
        return humansSavedCount;
    }
    public int TotalHumans()
    {
        return maxHumans;
    }
    public int GetScore()
    {
        return score;
    }
    public void AddScore(int points)
    {
        score += points;
        DisplayScore();
    }
    public void SubtractScore(int points)
    {
        score -= points;
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreText.text = $"Score: {score}";
        finalScoreText.text = scoreText.text;
    }
    void DisplayHumansSaved()
    {
        humanSavedText.text = $"Human's saved: {GetHumanSaved()}/{maxHumans}";
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            AddScore(PlayerPrefs.GetInt("Score"));
            gameRounds = PlayerPrefs.GetInt("Game Round");
        }

        maxHumans *= gameRounds;
        if (ThemeMusic.instance != null)
            ThemeMusic.instance.gameObject.SetActive(true);
        DisplayHumansSaved();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null && !isGameOver)
        {
            SetHighScore();

            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.DeleteKey("Game Round");
            if (ThemeMusic.instance != null)
                ThemeMusic.instance.gameObject.SetActive(false);
            loseUI.SetActive(true);
            isGameOver = true;
            finalScoreText.gameObject.SetActive(isGameOver);
        }
    }

    void SetHighScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            int newHighScore = PlayerPrefs.GetInt("Score");
            if (newHighScore > PlayerPrefs.GetInt("High Score"))
            {
                PlayerPrefs.SetInt("High Score", newHighScore);
            }
        }
    }
}
