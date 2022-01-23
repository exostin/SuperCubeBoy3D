using System.Collections;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    private const float DefaultCratePositionZ = 16f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject crate;
    [SerializeField] private float crateSpawnDelay = 0.405f;

    // Variables used to determine where the crate will spawn on x axis.
    private readonly float[] crateSpawnPositionsRangeOnX = {-5.5f, -3.5f, -1.5f, 1.5f, 3.5f, 5.5f};
    private float currentCratePositionZ;
    private int currentRandomIndex;
    private int lastRandomIndex;

    private void Start()
    {
        StartCrateSpawning();
    }

    public void StartCrateSpawning()
    {
        currentCratePositionZ = DefaultCratePositionZ;
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
            do
            {
                currentRandomIndex = Random.Range(0, crateSpawnPositionsRangeOnX.Length);
            } while (currentRandomIndex == lastRandomIndex ||
                     currentRandomIndex == lastRandomIndex + 1 ||
                     currentRandomIndex == lastRandomIndex - 1);

        var cratePositionX = crateSpawnPositionsRangeOnX[currentRandomIndex];
        var cratePositionZ = currentCratePositionZ + 8f;
        currentCratePositionZ = cratePositionZ;

        // Spawn "Crate(Clone)" and assign it under "Obstacles" parent.
        var crateClone = Instantiate(crate, new Vector3(cratePositionX, 0.5f, cratePositionZ), Quaternion.identity);
        crateClone.transform.parent = GameObject.Find("Obstacles").transform;
    }
}