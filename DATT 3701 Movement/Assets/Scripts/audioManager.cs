﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BGPref";
    private static readonly string SFXPref = "SFXPref";


    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;

    public Slider BGMToggle;
    public Slider SFXToggle;


    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    bool isChanged = false;
    bool isSFXChanged = false;

    float temp;
    float tempSFX;




    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        //first time user plays the game
        if(firstPlayInt == 0)
        {
            backgroundFloat = .125f;
            soundEffectsFloat = .55f;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;

            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SFXPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            soundEffectsFloat = PlayerPrefs.GetFloat(SFXPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;

        }

    }

    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SFXPref, soundEffectsFloat);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSetting();
        }
    }

    public void UpdateSound()
    {
        if(BGMToggle.value == 1 && !isChanged)
        {
            backgroundAudio.volume = backgroundSlider.value;
            temp = backgroundAudio.volume;

        }
        else if (BGMToggle.value == 0)
        {
            backgroundAudio.volume = 0f;
            backgroundSlider.value = backgroundAudio.volume;
            isChanged = true;

        }else if(BGMToggle.value == 1 && isChanged)
        {
            backgroundAudio.volume = temp;
            backgroundSlider.value = temp;
            isChanged = false;



        }

        if (SFXToggle.value == 1 && !isSFXChanged) {
            for (int i = 0; i < soundEffectsAudio.Length; i++)
            {
                soundEffectsAudio[i].volume = soundEffectsFloat;
            }
            tempSFX = soundEffectsFloat;

        }
        else if (SFXToggle.value == 0)
        {
            for (int i = 0; i < soundEffectsAudio.Length; i++)
            {
                soundEffectsAudio[i].volume = 0f;
            }
            soundEffectsSlider.value = 0f;

            isSFXChanged = true;
        }else if (SFXToggle.value == 1 && isSFXChanged)
        {
            for (int i = 0; i < soundEffectsAudio.Length; i++)
            {
                soundEffectsAudio[i].volume = tempSFX;
            }
            soundEffectsSlider.value = tempSFX;
            isSFXChanged = false;

        }


    }
}
