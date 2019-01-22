using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        StartCoroutine(fader());
    }

    IEnumerator fader()
    {
        //Begins fading to the next scene
        float fadeTime = GameObject.Find("LevelManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    //Call this when Replay is clicked
    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void MainMenu()
    {
        Application.LoadLevel(0);
    }
}
