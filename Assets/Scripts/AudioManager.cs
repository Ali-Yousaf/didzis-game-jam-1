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

    public AudioClip whooshSound;

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
}
