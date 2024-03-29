﻿using UnityEngine;

public class FollowPlayer_Platform : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private readonly float platformDistance = -173f;

    private void Update()
    {
        var position = transform.position;
        position.z = playerTransform.position.z - platformDistance;
        transform.position = position;
    }
}