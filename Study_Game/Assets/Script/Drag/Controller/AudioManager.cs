using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectsSliders;
    public float backgroundFloat, soundEffectsFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            backgroundFloat = .125f;
            soundEffectsFloat = .75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSliders.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectsSliders.value = soundEffectsFloat;
        }
    }
    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(BackgroundPref,backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSliders.value);
    }
    void OnApplicationFocus(bool isFocus)
    {
        if(!isFocus)
        {
            SaveSoundSetting();
        }
    }
    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
        
        for(int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSliders.value;
        }
    }
}
