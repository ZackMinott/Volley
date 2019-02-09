using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    public Text scoreText;
    public Text pauseScore;
    public Text highScore;
    [System.NonSerialized] public int score;

   

    void Start()
    {
        PlayerPrefs.SetInt("GameScore", 0);
        score = 0; //Score begins at 0 and increments every time a ball is hit
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateScore();
    }

  
    public void AddScore()
    {
        score += 1;
        UpdateScore();

        HighScore();

        PlayerPrefs.SetInt("GameScore", score);
    }

    //Update ScoreText
    void UpdateScore()
    {
        scoreText.text = score.ToString();
        pauseScore.text = score.ToString();
    }

    void HighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString(); //Might have to make sure this works later
        }
    }

}
