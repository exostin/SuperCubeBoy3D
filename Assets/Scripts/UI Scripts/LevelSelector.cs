using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private GameObject postprocessing;
    [SerializeField] private Camera cameraGo;
    [SerializeField] private GameObject obstaclesParent;
    [SerializeField] private GameObject crateSpawner;
    [SerializeField] private GameObject player, obstacle, platform, leftBoundary, rightBoundary;
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private GameObject difficultyCheckpoint;
    [SerializeField] private GameObject cometParticles;
    [SerializeField] private Material[] playerMaterials, obstacleMaterials, platformMaterials, boundaryMaterials;
    [SerializeField] private AudioClip[] backgroundMusicClips;
    [SerializeField] private VolumeProfile[] postprocessingVolumeProfiles;
    private GameManager gameManager;

    public int CurrentLevelIndex { get; set; }


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ChangeLevel()
    {
        gameManager.PlayerDeath();
        player.transform.position = new Vector3(0f, 0.5f, 0f);
        difficultyCheckpoint.transform.position = new Vector3(0f, 2f, 200f);

        // delete all generated obstacles
        foreach (Transform child in obstaclesParent.transform) Destroy(child.gameObject);
        cometParticles.SetActive(false);

        // Change post process profile to lvlIndex from profiles array
        postprocessing.GetComponent<Volume>().profile = postprocessingVolumeProfiles[CurrentLevelIndex];
        // Change map materials
        player.GetComponent<MeshRenderer>().material = playerMaterials[CurrentLevelIndex];
        obstacle.GetComponent<MeshRenderer>().material = obstacleMaterials[CurrentLevelIndex];
        platform.GetComponent<MeshRenderer>().material = platformMaterials[CurrentLevelIndex];
        leftBoundary.GetComponent<MeshRenderer>().material = boundaryMaterials[CurrentLevelIndex];
        rightBoundary.GetComponent<MeshRenderer>().material = boundaryMaterials[CurrentLevelIndex];
        // Change the speed variable of player object
        player.GetComponent<PlayerMovement>().forwardForce = 650f;
        player.GetComponent<PlayerMovement>().sidewaysForce = 550f;
        // Change the music
        backgroundMusicSource.clip = backgroundMusicClips[CurrentLevelIndex];
        backgroundMusicSource.Play();

        // change camera values
        switch (CurrentLevelIndex)
        {
            case 0:
                cameraGo.GetComponent<HDAdditionalCameraData>().clearColorMode =
                    HDAdditionalCameraData.ClearColorMode.Sky;
                break;
            case 1:
                cameraGo.GetComponent<HDAdditionalCameraData>().clearColorMode =
                    HDAdditionalCameraData.ClearColorMode.None;
                break;
            case 2:
                cameraGo.GetComponent<HDAdditionalCameraData>().clearColorMode =
                    HDAdditionalCameraData.ClearColorMode.Color;
                cameraGo.GetComponent<HDAdditionalCameraData>().backgroundColorHDR = Color.black;
                cometParticles.SetActive(true);
                break;
        }

        //crateSpawner.GetComponent<CrateSpawner>().StartCrateSpawning();
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}