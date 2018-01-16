using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource clickAudio;
    public AudioSource cardUseAudio;
    public AudioSource endTurnAudio;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayClickSound()
    {
        clickAudio.pitch = Random.Range(0.5f, 2f);
        clickAudio.Play();
    }

    public void PlayCardUseSound()
    {
        cardUseAudio.Play();
    }

    public void PlayEndTurnSound()
    {
        endTurnAudio.Play();
    }
}
