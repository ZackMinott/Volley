using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    /*
     * This Script is used for opening up menu canvases
     */
    [SerializeField] private Text highScore;
    [SerializeField] private Text gameScore;

    public void Awake()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        gameScore.text = PlayerPrefs.GetInt("GameScore", 0).ToString();
    }

	public void OpenCanvas(GameObject menuCanvas)
    {
        menuCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseCanvas(GameObject menuCanvas)
    {
        menuCanvas.SetActive(false);
        Time.timeScale = 1;
    }

}
