using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("Sound played on player death")]
    public AudioClip audioDeathSound;

    public GameObject pauseMenu;
    public GameObject timeManager;
    public GameObject levelSelectorGameObject;

    private bool audioIsMutedRightNow;

    private GameObject[] audioObjects;
    private bool pauseMenuIsToggledOnNow;

    private void Start()
    {
        audioObjects = GameObject.FindGameObjectsWithTag("Audio");
    }

    public void PlayerRespawn()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        levelSelectorGameObject.GetComponent<LevelSelector>().ChangeLevel();
    }

    public void PlayerDeath()
    {
        //deathSoundFX.GetComponent<AudioSource>().Play();
    }

    public void ToggleAudioMute()
    {
        for (var i = 0; i < audioObjects.Length; i++)
            audioObjects[i].GetComponent<AudioSource>().mute = !audioIsMutedRightNow;
        audioIsMutedRightNow = !audioIsMutedRightNow;
    }

    public void TogglePauseMenu()
    {
        pauseMenuIsToggledOnNow = !pauseMenuIsToggledOnNow;

        if (pauseMenuIsToggledOnNow)
        {
            timeManager.GetComponent<TimeManager>().SlowMotion();
            pauseMenu.SetActive(true);
        }
        else
        {
            timeManager.GetComponent<TimeManager>().NormalMotion();
            pauseMenu.SetActive(false);
        }
    }
}