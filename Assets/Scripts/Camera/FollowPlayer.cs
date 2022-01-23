using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    // Camera should be at 0f, -2f, 3.56f and with 10,0,0 rotation
    //private Vector3 cameraDistanceOffset = new Vector3(0f, -2f, 3.56f);

    [SerializeField] private Vector3 distanceOffset;

    private void LateUpdate()
    {
        transform.position = playerTransform.position - distanceOffset;
    }
}