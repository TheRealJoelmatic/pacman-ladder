using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Credits;
    public GameObject Settings;
    public GameObject Buttons;

    public GameObject mainBackground;
    public GameObject secondBackground;

    private bool fullscreen;

    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Dropdown textureDropdown;
    public Dropdown aaDropdown;
    public Slider volumeSlider;
    float currentVolume;
    Resolution[] resolutions;

    public void PlayThePacMan()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        AllOff();
        setBackground(0);
        Buttons.SetActive(true);
        PlayerPrefs.GetInt("IsFullscreen");

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " +
                     resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width
                  && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        volumeSlider.value = 1;

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    private void AllOff()
    {
        Credits.SetActive(false);
        Settings.SetActive(false);
    }

    public void OpenSettings()
    {
        AllOff();
        Settings.SetActive(true);
        setBackground(1);
    }
    public void OpenPlay()
    {
        AllOff();
        setBackground(0);
    }
    public void OpenCredits()
    {
        AllOff();
        Credits.SetActive(true);
        setBackground(1);
    }

    public void setBackground(int Back)
    {
        if (Back == 0)
        {
            mainBackground.SetActive(true);
            secondBackground.SetActive(false);
        }
        else
        {
            mainBackground.SetActive(false);
            secondBackground.SetActive(true);
        }
    }

    public void FullsceenToggle()
    {
        if (PlayerPrefs.GetInt("IsFullscreen") == 0)
        {
            Screen.fullScreen = true;
            PlayerPrefs.SetInt("IsFullscreen", 1);
        }
        else
        {
            Screen.fullScreen = false;
            PlayerPrefs.SetInt("IsFullscreen", 0);
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volumeSlider.value;
        currentVolume = volumeSlider.value;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("VolumePreference", volumeSlider.value);
    }
    public void LoadSettings(int currentResolutionIndex)
    {

        if (PlayerPrefs.GetInt("IsFullscreen") == 0)
            Screen.fullScreen = true;

        else
            Screen.fullScreen = false;
    }
}


