using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    MusicManager musicManager;
    Button toggleMusic;
    GameObject musicOn;
    GameObject musicOff;

    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        toggleMusic = GetComponent<Button>();
        toggleMusic.onClick.AddListener(HandleMusicToggle);
        GetIcons();
    }

    void GetIcons()
    {
        musicOn = transform.Find("Music_On").gameObject;
        musicOff = transform.Find("Music_Off").gameObject;
    }


    void HandleMusicToggle()
    {
        bool isMuted;
        isMuted = musicManager.ToggleMusic();
        ToggleMuteSprite(isMuted);
    }

    void ToggleMuteSprite(bool isMuted)
    {
        if (isMuted)
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
        else
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
    }
}
