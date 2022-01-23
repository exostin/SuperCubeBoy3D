using UnityEngine;
using UnityEngine.Audio;

public class PlayerPrefsInitialize : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixerMusic, audioMixerSounds;

    private int usedFullScreenMode;
    private float usedMusicVolume;
    private float usedSoundVolume;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("FullScreenMode"))
        {
            PlayerPrefs.SetInt("FullScreenMode", 1);
            PlayerPrefs.SetFloat("MusicVolume", 0);
            PlayerPrefs.SetFloat("SoundVolume", 0);
            PlayerPrefs.Save();
        }

        usedFullScreenMode = PlayerPrefs.GetInt("FullScreenMode");
        usedMusicVolume = PlayerPrefs.GetFloat("MusicVolume");
        usedSoundVolume = PlayerPrefs.GetFloat("SoundVolume");

        SetFullScreenMode(usedFullScreenMode);
        audioMixerMusic.SetFloat("MusicVolume", usedMusicVolume);
        audioMixerSounds.SetFloat("SoundVolume", usedSoundVolume);
    }

    public void SetFullScreenMode(int fullScreenModeIndex)
    {
        switch (fullScreenModeIndex)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
                break;

            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                Screen.SetResolution(1280, 720, false);
                break;
        }
    }
}