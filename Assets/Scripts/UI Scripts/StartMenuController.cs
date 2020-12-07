using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public GameObject menuMusic, backgroundMusic, cube;

    private Animator anim;

    private void Start()
    {
        anim = cube.GetComponent<Animator>();
    }

    // Play button
    public void StartButton()
    {
        StartCoroutine(LoadingAnimation());
        StartCoroutine(StartItAlready());
    }

    private IEnumerator LoadingAnimation()
    {
        anim.Play("CubeStartGameRotation", 0, 1f);
        yield return null;
    }

    private IEnumerator StartItAlready()
    {
        yield return new WaitForSeconds(1f);
        menuMusic.SetActive(false);
        //backgroundMusic.SetActive(true);
        SceneManager.LoadScene(2);
    }

    // Exit button
    public void ExitButton()
    {
        Application.Quit();
    }
}