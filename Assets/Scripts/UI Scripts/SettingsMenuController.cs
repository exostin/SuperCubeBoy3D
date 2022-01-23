using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    public AudioMixer audioMixerMusic, audioMixerSounds;

    [Header("Settings fields")] public TMP_Dropdown fullScreenDropdown;

    public Slider musicSlider, soundSlider;
    private int usedFullScreenMode;

    private float usedMusicVolume;
    private float usedSoundVolume;

    private void Awake()
    {
        usedMusicVolume = PlayerPrefs.GetFloat("MusicVolume");
        usedSoundVolume = PlayerPrefs.GetFloat("SoundVolume");
        usedFullScreenMode = PlayerPrefs.GetInt("FullScreenMode");

        SetFullScreenMode(usedFullScreenMode);
        SettingsSetMusicVolume();
        SettingsSetSoundsVolume();

        fullScreenDropdown.value = usedFullScreenMode;
        musicSlider.value = usedMusicVolume;
        soundSlider.value = usedSoundVolume;
    }

    public void SetFullScreenMode(int fullScreenModeIndex)
    {
        switch (fullScreenModeIndex)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
                PlayerPrefs.SetInt("FullScreenMode", 0);
                break;

            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                Screen.SetResolution(1280, 720, false);
                PlayerPrefs.SetInt("FullScreenMode", 1);
                break;
        }
    }

    public void SettingsSetMusicVolumeValue(float dynamicallySetMusicVolume)
    {
        usedMusicVolume = dynamicallySetMusicVolume;
        PlayerPrefs.SetFloat("MusicVolume", usedMusicVolume);
        SettingsSetMusicVolume();
    }

    public void SettingsSetMusicVolume()
    {
        audioMixerMusic.SetFloat("MusicVolume", usedMusicVolume);
    }

    public void SettingsSetSoundsVolumeValue(float dynamicallySetSoundVolume)
    {
        usedSoundVolume = dynamicallySetSoundVolume;
        PlayerPrefs.SetFloat("SoundVolume", usedSoundVolume);
        SettingsSetSoundsVolume();
    }

    public void SettingsSetSoundsVolume()
    {
        audioMixerSounds.SetFloat("SoundVolume", usedSoundVolume);
    }

    public void SavePreferences()
    {
        PlayerPrefs.Save();
    }
}