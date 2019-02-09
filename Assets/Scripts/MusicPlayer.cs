using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //[SerializeField] private GameObject[] gameSounds;
    //private AudioSource[] sounds;
    //private AudioSource music;
   

    private void Awake()
    {
        SetUpSingleton();

        
        
    }

    private void SetUpSingleton()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    // Update is called once per frame
    void Update () {
		
	}

    //public void OnMusicOff(GameObject musicOn)
    //{
    //    musicOn.SetActive(false);
    //    //musicOff.SetActive(true);
    //    PlayerPrefs.SetFloat("musicVolume", 0.0f);
    //    music.volume = PlayerPrefs.GetFloat("musicVolume");
    //}

    //public void musicOffActive(GameObject musicOff)
    //{
    //    musicOff.SetActive(true);
    //}

    //public void OnMusicOn(GameObject musicOff)
    //{  
    //    musicOff.SetActive(false);
    //    PlayerPrefs.SetFloat("musicVolume", 1.0f);
    //    music.volume = PlayerPrefs.GetFloat("musicVolume");
    //}

    //public void musicOnActive(GameObject musicOn)
    //{
    //    musicOn.SetActive(true);
    //}



    //public void OnSoundsOff(GameObject soundOn)
    //{
    //    soundOn.SetActive(false);
        
    //    PlayerPrefs.SetFloat("soundVolume", 0.0f);
    //    for (int i = 0; i < sounds.Length; i++)
    //    {
    //        sounds[i].volume = PlayerPrefs.GetFloat("soundVolume");
    //    }

    //}

    //public void soundOffActive(GameObject soundOff)
    //{
    //    soundOff.SetActive(true);
    //}

    //public void OnSoundsOn(GameObject soundOff)
    //{
    //    soundOff.SetActive(false);
    //    PlayerPrefs.SetFloat("soundVolume", 1.0f);
    //    for (int i = 0; i < sounds.Length; i++)
    //    {
    //        sounds[i].volume = PlayerPrefs.GetFloat("soundVolume");
    //    }

    //}

   
}
