using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Awake()
    {
        if (MultipleMusicPlayersExist())
        {
            DestroyAdditionalMusicPlayers();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMute();
        }
    }

    bool MultipleMusicPlayersExist()
    {
        MusicManager[] musicPlayers;
        musicPlayers = FindObjectsOfType<MusicManager>();
        if (musicPlayers.Length > 1)
        {
            return true;
        } else
        {
            return false;
        }
    }

    void DestroyAdditionalMusicPlayers()
    {
        Destroy(gameObject);
    }

    public void ToggleMute()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.mute = !audio.mute;
    }
}
