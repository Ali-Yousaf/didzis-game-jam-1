using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource SFXsource;

    [Header("Audio Clips")]

    public AudioClip gameAudio;

    public AudioClip gravityChangeSFX;

    public AudioClip buttonCollectSFX;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        musicSource.clip = gameAudio;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }

    public void PlayRandomizedPitchSFX(AudioClip clip)
    {
        SFXsource.pitch = Random.Range(0.8f, 1.2f);
        SFXsource.PlayOneShot(clip);
    }
}
