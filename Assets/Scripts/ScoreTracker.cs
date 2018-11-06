using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    public Text scoreText;
    [System.NonSerialized] public int score;

    void Start()
    {
        score = 0; //Score begins at 0 and increments every time a ball is hit
        UpdateScore();
    }

    public void AddScore()
    {
        score += 1;
        UpdateScore();
    }

    //Update ScoreText
    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
