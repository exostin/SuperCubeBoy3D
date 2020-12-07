using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public GameObject player, obstacle, platform, leftBoundary, rightBoundary;
    private GameManager gm;

    //private Material playerMaterial, obstacleMaterial, platformMaterial, leftBoundaryMaterial, rightBoundaryMaterial;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        //playerMaterial = player.GetComponent<Material>();
        //obstacleMaterial = obstacle.GetComponent<Material>();
        //platformMaterial = platform.GetComponent<Material>();
        //leftBoundaryMaterial = leftBoundary.GetComponent<Material>();
        //rightBoundaryMaterial = rightBoundary.GetComponent<Material>();
    }

    public void ChangeLevel(int lvlIndex)
    {
        switch (lvlIndex)
        {
            case 0:
                gm.PlayerDeath();
                // Start the loading screen
                // Change post process profile to index 0 from profiles array
                // Change material of platform
                // Change material of boundaries
                // Change material of player
                // Change material of obstacles
                // Change the speed variable of player object
                // Change the music
                // End the loading screen
                break;

            case 1:
                gm.PlayerDeath();
                // Call PlayerDeath;
                // Start the loading screen
                // Reset player position
                // Change post process profile to index 0 from profiles array
                // Change material of platform
                // Change material of boundaries
                // Change material of player
                // Change material of obstacles
                // Change the speed variable of player object
                // Change the music
                // End the loading screen
                break;

            case 2:
                gm.PlayerDeath();
                // Call PlayerDeath;
                // Start the loading screen
                // Reset player position
                // Change post process profile to index 0 from profiles array
                // Change material of platform
                // Change material of boundaries
                // Change material of player
                // Change material of obstacles
                // Change the speed variable of player object
                // Change the music
                // End the loading screen
                break;

            case 3:
                gm.PlayerDeath();
                // Call PlayerDeath;
                // Start the loading screen
                // Reset player position
                // Change post process profile to index 0 from profiles array
                // Change material of platform
                // Change material of boundaries
                // Change material of player
                // Change material of obstacles
                // Change the speed variable of player object
                // Change the music
                // End the loading screen
                break;

            default:
                Debug.Log("Wrong index input received into ChangeLevel function! (LevelSelector.cs)");
                break;
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}