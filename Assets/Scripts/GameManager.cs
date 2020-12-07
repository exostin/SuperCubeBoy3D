using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("Sound played on player death")]
    public AudioClip audioDeathSound;

    private bool audioIsMutedRightNow = false;
    private bool pauseMenuIsToggledOnNow = false;

    private GameObject[] audioObjects;

    public GameObject pauseScreenGO;
    public GameObject timeManagerGO;

    private TimeManager timeManager;

    private void Start()
    {
        timeManager = timeManagerGO.GetComponent<TimeManager>();
        audioObjects = GameObject.FindGameObjectsWithTag("Audio");
    }

    public void PlayerRespawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerDeath()
    {
        //deathSoundFX.GetComponent<AudioSource>().Play();
    }

    public void ToggleAudioMute()
    {
        for (int i = 0; i < audioObjects.Length; i++)
        {
            audioObjects[i].GetComponent<AudioSource>().mute = !audioIsMutedRightNow;
        }
        audioIsMutedRightNow = !audioIsMutedRightNow;
    }

    public void TogglePauseMenu()
    {
        pauseMenuIsToggledOnNow = !pauseMenuIsToggledOnNow;

        if (pauseMenuIsToggledOnNow)
        {
            timeManager.SlowMotion();
            pauseScreenGO.SetActive(true);
        }
        else
        {
            timeManager.NormalMotion();
            pauseScreenGO.SetActive(false);
        }
    }
}