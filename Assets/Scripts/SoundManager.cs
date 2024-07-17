using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private bool _muteBackgroundMusic;
    private bool _muteSoundfx;

    
    public static SoundManager instance;

    private AudioSource _audioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    public void ToggleBackgroundMusic()
    {
        _muteBackgroundMusic = !_muteBackgroundMusic;
        if(_muteBackgroundMusic)
        {
            _audioSource.Stop();

        }
        else
        {
            _audioSource.Play();
        }
    }
    public void ToggleSoundfx()
    {
        _muteSoundfx = !_muteSoundfx;
        GameEvents.ToggleSoundfxMethod();
    }
    public bool IsBackgroundMusicMuted()
    {
        return _muteBackgroundMusic;
    }
    public bool IsSoundFxMuted()
    {
        return _muteSoundfx;
    }
    public void SilienceBackgroundMusic(bool silience)
    {
        if(_muteBackgroundMusic == false)
        {
            if (silience)
            {
                _audioSource.volume = 0f;

            }
            else
            {
                _audioSource.volume = 1f;
            }
        }
    }
}
