using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    AudioSource backgroundAudio;
    [SerializeField]
    AudioSource effectAudio;
    [SerializeField]
    AudioSource effectAudio2;
    [SerializeField]
    AudioClip shootClip;
    [SerializeField]
    AudioClip coinClip;
    [SerializeField]
    AudioClip explosionClip;
    [SerializeField]
    AudioClip buttonClip;
    [SerializeField]
    AudioClip walkClip;
    [SerializeField]
    private GameObject bgOn_Start, bgOff_Start, effectOn_Start, effectOff_Start, bgOn_Pause, bgOff_Pause, effectOn_Pause, effectOff_Pause;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(Constants.AudioInfo.ISBACKGROUND) == 0)
        {
            backgroundAudio.mute = false;
            bgOn_Start.SetActive(true);
            bgOn_Pause.SetActive(true);
            bgOff_Start.SetActive(false);
            bgOff_Pause.SetActive(false);
        }
        else if (PlayerPrefs.GetInt(Constants.AudioInfo.ISBACKGROUND) == 1)
        {
            backgroundAudio.mute = true;
            bgOn_Start.SetActive(false);
            bgOn_Pause.SetActive(false);
            bgOff_Start.SetActive(true);
            bgOff_Pause.SetActive(true);
        }

        if (PlayerPrefs.GetInt(Constants.AudioInfo.ISEFFECT) == 0)
        {
            effectAudio.mute = false;
            effectAudio2.mute = false;
            effectOn_Start.SetActive(true);
            effectOn_Pause.SetActive(true);
            effectOff_Start.SetActive(false);
            effectOff_Pause.SetActive(false);
        }
        else if (PlayerPrefs.GetInt(Constants.AudioInfo.ISEFFECT) == 1)
        {
            effectAudio.mute = true;
            effectAudio2.mute = true;

            effectOn_Start.SetActive(false);
            effectOn_Pause.SetActive(false);
            effectOff_Start.SetActive(true);
            effectOff_Pause.SetActive(true);
        }
    }

    public void PlayShootAudio()
    {
        effectAudio.clip = shootClip;
        effectAudio.Play();
    }

    public void PlayCoinAudio()
    {
        effectAudio.clip = coinClip;
        effectAudio.Play();
    }

    public void PlayExplosionClip()
    {
        effectAudio2.Stop();
        effectAudio2.clip = explosionClip;
        effectAudio2.Play();
    }

    public void PlayButtonAudio()
    {
        effectAudio.clip = buttonClip;
        effectAudio.Play();
    }

    public void PlayWalkAudio()
    {
        effectAudio2.clip = walkClip;
        effectAudio2.Play();
        effectAudio2.loop = true;
        StartCoroutine(TurnOffLoop());
    }

    IEnumerator TurnOffLoop()
    {
        yield return new WaitForSeconds(2);
        effectAudio2.clip = null;
        effectAudio2.loop = false;
    }

    public void TurnOffBackgroundMusic()
    {
        PlayButtonAudio();
        backgroundAudio.mute = true;
        bgOn_Start.SetActive(false);
        bgOn_Pause.SetActive(false);
        bgOff_Start.SetActive(true);
        bgOff_Pause.SetActive(true);
        PlayerPrefs.SetInt(Constants.AudioInfo.ISBACKGROUND, 1);
    }
    public void TurnOnBackgroundMusic()
    {
        PlayButtonAudio();
        backgroundAudio.mute = false;
        bgOn_Start.SetActive(true);
        bgOn_Pause.SetActive(true);
        bgOff_Start.SetActive(false);
        bgOff_Pause.SetActive(false);
        PlayerPrefs.SetInt(Constants.AudioInfo.ISBACKGROUND, 0);
    }
    public void TurnOffEffectMusic()
    {
        PlayButtonAudio();
        effectAudio.mute = true;
        effectAudio2.mute = true;
        effectOn_Start.SetActive(false);
        effectOn_Pause.SetActive(false);
        effectOff_Start.SetActive(true);
        effectOff_Pause.SetActive(true);
        PlayerPrefs.SetInt(Constants.AudioInfo.ISEFFECT, 1);
    }
    public void TurnOnEffectMusic()
    {
        PlayButtonAudio();
        effectAudio.mute = false;
        effectAudio2.mute = false;
        effectOn_Start.SetActive(true);
        effectOn_Pause.SetActive(true);
        effectOff_Start.SetActive(false);
        effectOff_Pause.SetActive(false);
        PlayerPrefs.SetInt(Constants.AudioInfo.ISEFFECT, 0);
    }


}
