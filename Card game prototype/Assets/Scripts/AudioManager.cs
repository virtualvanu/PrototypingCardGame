using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource clickAudio;
    public AudioSource cardUseAudio;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayClickSound()
    {
        clickAudio.Play();
    }

    public void PlayCardUseSound()
    {
        cardUseAudio.Play();
    }
}
