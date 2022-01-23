using UnityEngine;

public class DifficultyScaling : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform barrierTransform;

    [SerializeField] private float difficultySpeedScalingValue = 10;

    private void OnTriggerEnter(Collider playerCollision1)
    {
        if (playerCollision1.gameObject.CompareTag("Player"))
        {
            playerMovement.forwardForce += difficultySpeedScalingValue;
            playerMovement.sidewaysForce += difficultySpeedScalingValue * 0.90f;
        }
    }

    private void OnTriggerExit(Collider playerCollision2)
    {
        if (playerCollision2.gameObject.CompareTag("Player")) barrierTransform.Translate(0f, 0f, 20f);
    }
}