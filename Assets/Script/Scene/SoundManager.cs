using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    static public SoundManager Instance;
    [SerializeField]
    AudioMixer mixer;
    public AudioMixer Mixer { get { return mixer; } }
    public float MasterVolume
    {
        get { return masterVolume; }
        set { masterVolume = value; SoundManager.Instance.mixer.SetFloat("MasterVolume", masterVolume); }
    }
    public float MasterVolumeDefault { get { return masterVolumeDefault; } }
    public float MusicVolume
    {
        get { return musicVolume; }
        set { musicVolume = value; SoundManager.Instance.Mixer.SetFloat("MusicVolume", musicVolume); }
    }
    public float MusicVolumeDefault { get { return musicVolumeDefault; } }
    public float MasterSFXVolume
    {
        get { return masterSFXVolume; }
        set { masterSFXVolume = value; SoundManager.Instance.Mixer.SetFloat("MasterSFXVolume", masterSFXVolume); }
    }
    public float MasterSFXVolumeDefault { get { return masterSFXVolumeDefault; } }

    float masterVolume;
    float masterVolumeDefault;
    float musicVolume;
    float musicVolumeDefault;
    float masterSFXVolume;
    float masterSFXVolumeDefault;

    private void Awake()
    {
        SetMasterSoundVolume();
        SetMasterSFXSoundVolume();
        SetMusicSoundVolume();
    }

    /* set on option menu example
     * 1.set bar ui
         musicSoundBar.value = Mathf.Pow(10, SoundManager.Instance.MusicVolumeDefault / 20);
         SFXSoundBar.value = Mathf.Pow(10, SoundManager.Instance.MasterSFXVolumeDefault / 20);
       2.set volume
         SoundManager.Instance.MusicVolume = Mathf.Log10( scrollbar.value)*20;
         SoundManager.Instance.MasterSFXVolume = Mathf.Log10( scrollbar.value)*20;
     */

    public void SetMasterSoundVolume()
    {
        float masterVolume;
        if (mixer.GetFloat("MasterVolume", out masterVolume))
            masterVolumeDefault = masterVolume;
    }

    public void SetMasterSFXSoundVolume()
    {
        float masterSFXVolume;
        if (mixer.GetFloat("MasterSFXVolume", out masterSFXVolume))
            masterSFXVolumeDefault = masterSFXVolume;
    }

    public void SetMusicSoundVolume()
    {
        float musicVolume;
        if (mixer.GetFloat("MusicVolume", out musicVolume))
            musicVolumeDefault = musicVolume;
    }
}
