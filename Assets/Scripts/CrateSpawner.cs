using System.Collections;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject crate;
    public float crateSpawnDelay = 0.405f;

    // Variables used to determine where the crate will spawn on x axis.
    private float[] crateSpawnPositionsRangeOnX = { -5.5f, -3.5f, -1.5f, 1.5f, 3.5f, 5.5f };

    private const float defaultCratePositionZ = 16f;
    private float currentCratePositionZ;
    private int currentRandomIndex = 0;
    private int lastRandomIndex;

    void Start()
    {
        StartCrateSpawning();
    }

    public void StartCrateSpawning()
    {
        currentCratePositionZ = defaultCratePositionZ;
        StartCoroutine(SpawnCrateIEnum());
    }

    private IEnumerator SpawnCrateIEnum()
    {
        while (true)
        {
            SpawnCrate();
            yield return new WaitForSeconds(crateSpawnDelay);
        }
    }

    private void SpawnCrate()
    {
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
        float cratePositionX = crateSpawnPositionsRangeOnX[currentRandomIndex];
        float cratePositionZ = currentCratePositionZ + 8f;
        currentCratePositionZ = cratePositionZ;

        // Spawn "Crate(Clone)" and assign it under "Obstacles" parent.
        var crateClone = Instantiate(crate, new Vector3(cratePositionX, 0.5f, cratePositionZ), Quaternion.identity);
        crateClone.transform.parent = GameObject.Find("Obstacles").transform;
    }
}