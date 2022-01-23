using UI_Scripts;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject scoreTracker;
    [SerializeField] private GameObject player;

    // Component variables

    private GameManager gm;
    private PlayerMovement pMovement;
    private Score scoreScript;

    private void Start()
    {
        pMovement = player.GetComponent<PlayerMovement>();
        scoreScript = scoreTracker.GetComponent<Score>();
        gm = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collisionEnter)
    {
        if (collisionEnter.gameObject.CompareTag("Obstacle"))
        {
            pMovement.forwardForce = 0f;
            pMovement.sidewaysForce = 0f;
            gm.PlayerDeath();
            StartCoroutine(scoreScript.TextFade());

            // !score = (int)gameObject.transform.position.z;
            // Instantiate(inputFieldPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            // Highscores.AddNewHighscore(username: username, score: score);
        }
    }
}