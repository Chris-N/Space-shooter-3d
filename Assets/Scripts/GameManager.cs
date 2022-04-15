using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int humansSavedCount = 0;
    [SerializeField] int maxHumans = 10;
    [SerializeField] int score = 0;

    [SerializeField] GameObject player;
    [HideInInspector] public bool isGameOver = false;
    [SerializeField] TextMeshProUGUI humanSavedText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;

    public void IncrementHumanSaved()
    {
        humansSavedCount++;
        DisplayHumansSaved();

        if (humansSavedCount == maxHumans)
        {
            winUI.SetActive(true);
            isGameOver = true;
            player.GetComponent<SphereCollider>().enabled = false;
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
    }
    void DisplayHumansSaved()
    {
        humanSavedText.text = $"Human's saved: {GetHumanSaved()}/{maxHumans}";
    }

    // Start is called before the first frame update
    void Start()
    {
        ThemeMusic.instance.gameObject.SetActive(true);
        DisplayHumansSaved();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null && !isGameOver)
        {
            if (ThemeMusic.instance != null)
                ThemeMusic.instance.gameObject.SetActive(false);
            loseUI.SetActive(true);
            isGameOver = true;
        }
    }
}
