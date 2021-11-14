using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.HighDefinition;

public class LevelSelector : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject postprocessing;
    public Camera cameraGO;
    public GameObject obstaclesParent;
    public GameObject crateSpawner;
    public GameObject player, obstacle, platform, leftBoundary, rightBoundary;
    public AudioSource backgroundMusicSource;
    public GameObject difficultyCheckpoint;
    public GameObject cometParticles;
    public Material[] playerMaterials, obstacleMaterials, platformMaterials, boundaryMaterials;
    public AudioClip[] backgroundMusicClips;
    public VolumeProfile[] postprocessingVolumeProfiles;

    public int CurrentLevelIndex { get; set; } = 0;
    

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
        foreach (Transform child in obstaclesParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
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
                cameraGO.GetComponent<HDAdditionalCameraData>().clearColorMode = HDAdditionalCameraData.ClearColorMode.Sky;
                break;
            case 1:
                cameraGO.GetComponent<HDAdditionalCameraData>().clearColorMode = HDAdditionalCameraData.ClearColorMode.None;
                break;
            case 2:
                cameraGO.GetComponent<HDAdditionalCameraData>().clearColorMode = HDAdditionalCameraData.ClearColorMode.Color;
                cameraGO.GetComponent<HDAdditionalCameraData>().backgroundColorHDR = Color.black;
                cometParticles.SetActive(true);
                break;
        }

        crateSpawner.GetComponent<CrateSpawner>().StartCrateSpawning();
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}