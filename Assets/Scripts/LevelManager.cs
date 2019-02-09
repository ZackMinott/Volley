using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        StartCoroutine(fader(name));
    }

    IEnumerator fader(string name)
    {
        //Begins fading to the next scene
        float fadeTime = GameObject.Find("LevelManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(name);
    }

    //Call this when Replay is clicked
    public void Restart()
    {
        SceneManager.LoadScene("GameScreen");
        Time.timeScale = 1f;
    }

    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        StartCoroutine(DelayLoad("Game Over"));
        //StartCoroutine(fader("Game Over"));
    }

    IEnumerator DelayLoad(string level)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(level);
    }
}
