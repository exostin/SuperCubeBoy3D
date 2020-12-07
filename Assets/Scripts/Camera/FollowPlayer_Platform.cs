using UnityEngine;

public class FollowPlayer_Platform : MonoBehaviour
{
    public Transform playerTransform;

    private float platformDistance = -173f;

    private void Update()
    {
        Vector3 position = transform.position;
        position.z = playerTransform.position.z - platformDistance;
        transform.position = position;
    }
}