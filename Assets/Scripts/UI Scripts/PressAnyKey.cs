using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UI_Scripts
{
    public class PressAnyKey : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pressAnyKeyText;
        private readonly float dottingInterval = 0.6f;
        private string dots;
        private bool dottingRunning = true;

        private Keyboard kb;

        private void Start()
        {
            kb = InputSystem.GetDevice<Keyboard>();
            StartCoroutine(AnyKeyDotting());
        }

        private void Update()
        {
            if (kb.anyKey.wasReleasedThisFrame)
            {
                dottingRunning = false;
                SceneManager.LoadScene(1);
            }
        }

        private IEnumerator AnyKeyDotting()
        {
            while (dottingRunning)
                for (var i = 0; i < 4; i++)
                {
                    dots = new string('.', i);
                    pressAnyKeyText.SetText("Press any key to continue" + dots);

                    yield return new WaitForSeconds(dottingInterval);
                }
        }
    }
}