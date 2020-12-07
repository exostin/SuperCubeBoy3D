using System.Collections;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    public GameObject crate;
    public Transform playerTransform;
    public float crateSpawnTime = 0.405f;

    // Variables used to determine where the crate will spawn on x axis.
    private float[] crateSpawnPositionsRangeOnX = { -5.5f, -3.5f, -1.5f, 1.5f, 3.5f, 5.5f };

    private float currentCratePositionZ = 16f;
    private int currentRandomIndex = 0;
    private int lastRandomIndex;

    private void Start()
    {
        StartCoroutine(SpawnCrateIEnum());
    }

    public IEnumerator SpawnCrateIEnum()
    {
        while (true)
        {
            SpawnCrate();
            yield return new WaitForSeconds(crateSpawnTime);
        }
    }

    private void SpawnCrate()
    {
        // If crate.z - player pos.z < 384????

        // Loop preventing crates being spawned at the same or close-by position.
        lastRandomIndex = currentRandomIndex;
        currentRandomIndex = Random.Range(0, crateSpawnPositionsRangeOnX.Length);
        if (currentRandomIndex == lastRandomIndex)
        {
            do
            {
                currentRandomIndex = Random.Range(0, crateSpawnPositionsRangeOnX.Length);
            } while (currentRandomIndex == lastRandomIndex ||
                currentRandomIndex == lastRandomIndex + 1 ||
                currentRandomIndex == lastRandomIndex - 1);
        }
        float cratePosX = crateSpawnPositionsRangeOnX[currentRandomIndex];
        float cratePosZ = currentCratePositionZ + 8f;
        currentCratePositionZ = cratePosZ;

        // Spawn "Crate(Clone)" and assign it under "Obstacles" parent.
        var crateClone = Instantiate(crate, new Vector3(cratePosX, 0.5f, cratePosZ), Quaternion.identity);
        crateClone.transform.parent = GameObject.Find("Obstacles").transform;
    }
}