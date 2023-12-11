using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score = 0;
    public float killscore = 0;
    public Timer timer;
    private float highScore = 0; // Change int to float for highScore
    private string highScoreKey = "HighScore";
    public bool isHighScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat(highScoreKey, 0);
        killscore = GameManager.Instance.killScore;
    }

    // Update is called once per frame
    void Update()
    {


        GameScore();
        if (GameManager.Instance.isGameOver == true)
        {
            HighScore();
            Debug.Log(highScore);
        }
        if (isHighScore != true)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        if (isHighScore == true) 
        {
            scoreText.text = "High Score: " + highScore.ToString();
        }

    }

    void GameScore()
    {
        score = (((timer.minutes * 60) + timer.seconds) * 5) + (killscore*10);
    }

    public void HighScore()
    {
        if (score > highScore)
        {
            highScore = score; // Update highScore if the current score is higher
            PlayerPrefs.SetFloat(highScoreKey, highScore);
            PlayerPrefs.Save();
        }
    }
}
