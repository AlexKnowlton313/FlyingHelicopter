using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int score;
    private float timeRemaining;
    private bool gamePlaying;
    public Text scoreText;
    public Text timeText;
    public GameObject resetButton;
    public Text gameOverText;
    public HelicopterControl heliControl;
    public Text waterGaugeText;
    public Image waterGaugeImage;

    public float startingWater = 500;

    void Start()
    {
        score = 0;
        timeRemaining = 180f;
        UpdateScore();

        resetButton.SetActive(false);
        gameOverText.text = "Find the Helipad!";
    }

    private void Update()
    {
        if (timeRemaining > 0f && gamePlaying)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTime();
        } else if (gamePlaying)
        {
            timeRemaining = 0f;
            gameOver("Out of time!");
        }
    }

    public void BeginGame()
    {
        gameOverText.text = "Press RT to takeoff!";
        Debug.Log("Found the helipad.");
    }

    public void TakeOffComplete()
    {
        gameOverText.text = "";
        gamePlaying = true;
        Debug.Log("Takeoff Completed.");

    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
        UpdateTime();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void UpdateTime()
    {
        timeText.text = "Time: " + timeRemainingToString();
    }

    private string timeRemainingToString()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.RoundToInt(timeRemaining % 60f);

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void reduceWaterGauge()
    {
        waterGaugeImage.fillAmount -= 1.0f / startingWater;

        if (waterGaugeImage.fillAmount == 0)
        {
            waterGaugeText.text = "Out of water!";
            heliControl.stopDroppingWater();
        }
    }

    public void gameOver(string reason)
    {
        gamePlaying = false;
        resetButton.SetActive(true);
        gameOverText.text = reason;
        heliControl.stopControl();
    }

    public void landed()
    {
        gamePlaying = false;
        resetButton.SetActive(true);
        gameOverText.text = "You Win!";
        heliControl.stopControl();
        AddScore(Mathf.RoundToInt(timeRemaining) * 5);
    }

    public void Reset()
    {
        SceneManager.LoadScene("flying-helicopter");
    }
}