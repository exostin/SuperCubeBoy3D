using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CrateSpawner : MonoBehaviour
{
    private const float DefaultCratePositionZ = 16f;

    [Header("References")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject crate;

    [Header("Spawn Settings")]
    [SerializeField] private int poolSize = 12; // Number of crates before recycle
    [SerializeField] private float spawnSpacingZ = 8f; // Distance between crates
    [SerializeField] private float recycleDistanceBehindPlayer = 10f;

    private readonly float[] spawnLanesX = { -5.5f, -3.5f, -1.5f, 1.5f, 3.5f, 5.5f };

    private List<GameObject> cratePool;
    private Transform obstaclesParent;

    private float nextSpawnZ;
    private int lastLaneIndex = -1;

    private void Start()
    {
        obstaclesParent = GameObject.Find("Obstacles").transform;
        InitializePool();
    }

    private void InitializePool()
    {
        cratePool = new List<GameObject>();
        
        // Create and place
        nextSpawnZ = DefaultCratePositionZ;
        for (int i = 0; i < poolSize; i++)
        {
            int laneIndex = GetRandomLaneIndex();
            Vector3 spawnPos = new Vector3(spawnLanesX[laneIndex], 0.5f, nextSpawnZ);

            // Spawn "Crate(Clone)" and assign it under "Obstacles" parent.
            GameObject crate = Instantiate(this.crate, spawnPos, Quaternion.identity, obstaclesParent);
            cratePool.Add(crate);

            nextSpawnZ += spawnSpacingZ;
        }
    }

    private void Update()
    {
        RecycleCrates();
    }

    private void RecycleCrates()
    {
        foreach (var crate in cratePool)
        {
            // If the crate is far enough behind the player, teleport it in front
            if (crate.transform.position.z < playerTransform.position.z - recycleDistanceBehindPlayer)
            {
                int laneIndex = GetRandomLaneIndex();
                Vector3 newPos = new Vector3(spawnLanesX[laneIndex], 0.5f, nextSpawnZ);
                crate.transform.position = newPos;

                nextSpawnZ += spawnSpacingZ;
            }
        }
    }

    private int GetRandomLaneIndex()
    {
        int laneIndex;
        do
        {
            laneIndex = Random.Range(0, spawnLanesX.Length);
        } while (laneIndex == lastLaneIndex ||
                 laneIndex == lastLaneIndex + 1 ||
                 laneIndex == lastLaneIndex - 1);

        lastLaneIndex = laneIndex;
        return laneIndex;
    }
}