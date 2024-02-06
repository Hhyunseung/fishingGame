using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip[] audioClips;

    public AudioSource bgSource;
    public AudioSource efSource;
    public AudioSource clSource;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance.gameObject);
        DontDestroyOnLoad(Instance.gameObject);

        bgSource.loop = true;
        clSource.clip = audioClips[0];
    }

    public void PlayBGSound(string type)
    {
        switch (type)
        {
            case "Title": bgSource.clip = audioClips[1]; break;
            case "Main":  bgSource.clip = audioClips[2]; break;
        }

        bgSource.Play();
    }

    public void PlayEFSound(string type)
    {
        switch (type)
        {
            case "Fishing": efSource.clip = audioClips[3]; break;
            case "Quest":   efSource.clip = audioClips[4]; break;
            case "Event":   efSource.clip = audioClips[5]; break;
        }

        efSource.Play();
    }
}
