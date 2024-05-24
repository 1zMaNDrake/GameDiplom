using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using System;

public class Settings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Slider musicSlider;
    public Slider sfxSlider;
    float currentMusic;
    float currentSFX;
    Resolution[] resolutions;

    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new();
        resolutions = Screen.resolutions.Select(res => new { res, ratio = (double)res.width / res.height })
                                 .Where(x => Math.Abs(x.ratio - 16.0 / 9) < 0.01)
                                 .Select(x => x.res)
                                 .ToArray();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " ";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width
                  && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void SetMusic()
    {
        AudioManager.Instance.MusicVolume(musicSlider.value);
        currentMusic = musicSlider.value;
    }

    public void SetSFX()
    {
        AudioManager.Instance.SFXVolume(sfxSlider.value);
        currentSFX = sfxSlider.value;
    }

    public void MuteMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void MuteSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("ResolutionPreference",
                   resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference",
                   System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("MusicPreference",
                   currentMusic);
        PlayerPrefs.SetFloat("SFXPreference",
                   currentSFX);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value =
                         PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIndex;

        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen =
            System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;

        if (PlayerPrefs.HasKey("MusicPreference"))
            musicSlider.value =
                        PlayerPrefs.GetFloat("MusicPreference");
        else
            musicSlider.value = 0.5f; 

        if (PlayerPrefs.HasKey("SFXPreference"))
            sfxSlider.value =
                        PlayerPrefs.GetFloat("SFXPreference");
        else
            sfxSlider.value = 0.5f; 
    }
}