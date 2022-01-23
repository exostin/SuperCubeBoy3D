using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement physics")] public float forwardForce = 650f;

    public float sidewaysForce = 550f;

    [SerializeField] private bool aKeyPressed;

    private bool audioMuteWasToggledByInput;
    private bool dKeyPressed;

    private GameManager gm;
    private Keyboard kb;
    private bool pauseMenuWasToggledByInput;
    private Rigidbody rb;
    private bool respawnToggled;
    private bool shiftKeyPressed;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        kb = InputSystem.GetDevice<Keyboard>();
    }

    private void Update()
    {
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)
            aKeyPressed = true;
        else
            aKeyPressed = false;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed)
            dKeyPressed = true;
        else
            dKeyPressed = false;

        if (kb.shiftKey.isPressed)
            shiftKeyPressed = true;
        else
            shiftKeyPressed = false;
        if (kb.rKey.wasReleasedThisFrame || kb.upArrowKey.wasReleasedThisFrame) respawnToggled = true;
        if (kb.escapeKey.wasReleasedThisFrame) pauseMenuWasToggledByInput = true;
        if (pauseMenuWasToggledByInput)
        {
            pauseMenuWasToggledByInput = false;
            gm.TogglePauseMenu();
        }

        if (kb.mKey.wasReleasedThisFrame) audioMuteWasToggledByInput = true;

        // Level selection
        if (kb.digit1Key.wasReleasedThisFrame)
        {
            gm.levelSelectorGameObject.GetComponent<LevelSelector>().CurrentLevelIndex = 0;
            gm.levelSelectorGameObject.GetComponent<LevelSelector>().ChangeLevel();
        }

        if (kb.digit2Key.wasReleasedThisFrame)
        {
            gm.levelSelectorGameObject.GetComponent<LevelSelector>().CurrentLevelIndex = 1;
            gm.levelSelectorGameObject.GetComponent<LevelSelector>().ChangeLevel();
        }

        if (kb.digit3Key.wasReleasedThisFrame)
        {
            gm.levelSelectorGameObject.GetComponent<LevelSelector>().CurrentLevelIndex = 2;
            gm.levelSelectorGameObject.GetComponent<LevelSelector>().ChangeLevel();
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(forwardForce * Time.fixedDeltaTime * Vector3.forward, ForceMode.VelocityChange);

        if (aKeyPressed) rb.AddForce(sidewaysForce * Time.fixedDeltaTime * Vector3.left, ForceMode.VelocityChange);
        if (dKeyPressed) rb.AddForce(sidewaysForce * Time.fixedDeltaTime * Vector3.right, ForceMode.VelocityChange);
        if (shiftKeyPressed)
            Time.timeScale = 0.1f;
        else
            Time.timeScale = 1f;
        if (respawnToggled)
        {
            respawnToggled = false;
            gm.PlayerRespawn();
        }

        if (audioMuteWasToggledByInput)
        {
            audioMuteWasToggledByInput = false;
            gm.ToggleAudioMute();
        }
    }
}