using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour {

    public GameObject[] gameSounds;
    private AudioSource[] sounds;
    private AudioSource music;
    public GameObject toggleOn, toggleOff;
    public GameObject musicPlayer;

    public void Awake()
    {
        
        PlayerPrefs.SetFloat("soundVolume", 0.0f);
        PlayerPrefs.SetFloat("musicVolume", 0.0f);

        music = musicPlayer.GetComponent<AudioSource>();

        for (int i = 0; i < gameSounds.Length; i++)
        {
            Debug.Log("Try");
            Debug.Log(gameSounds.Length);
            sounds[i] = gameSounds[i].GetComponent<AudioSource>();
        }

    }

    public void soundOnActive(GameObject soundOn)
    {
        soundOn.SetActive(true);
    }

    public void onMusicToggle()
    {
        

        bool onSwitch = gameObject.GetComponent<UnityEngine.UI.Toggle>().isOn;

        if (onSwitch)
        {
            toggleOn.SetActive(true);
            toggleOff.SetActive(false);
            PlayerPrefs.SetFloat("musicVolume", 1.0f);
            music.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        else if(!onSwitch)
        {
            toggleOn.SetActive(false);
            toggleOff.SetActive(true);
            PlayerPrefs.SetFloat("musicVolume", 0.0f);
            music.volume = PlayerPrefs.GetFloat("musicVolume");
        }
    }

    public void onSoundToggle()
    {
        

        bool onSwitch = gameObject.GetComponent<UnityEngine.UI.Toggle>().isOn;

        if (onSwitch)
        {
            toggleOn.SetActive(true);
            toggleOff.SetActive(false);
            PlayerPrefs.SetFloat("soundVolume", 1.0f);
            for (int i = 0; i < sounds.Length; i++)
            {
                Debug.Log("TryOff");
                sounds[i].volume = PlayerPrefs.GetFloat("soundVolume");
            }
        }
        else if(!onSwitch)
        {
            toggleOn.SetActive(false);
            toggleOff.SetActive(true);
            PlayerPrefs.SetFloat("soundVolume", 0.0f);
            for (int i = 0; i < sounds.Length; i++)
            {
                Debug.Log("tryOn");
                sounds[i].volume = PlayerPrefs.GetFloat("soundVolume");
            }
        }
    }

}
