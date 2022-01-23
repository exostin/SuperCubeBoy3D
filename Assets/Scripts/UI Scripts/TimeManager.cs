using System.Collections;
using UnityEngine;

namespace UI_Scripts
{
    public class TimeManager : MonoBehaviour
    {
        public void SlowMotion()
        {
            Time.timeScale = 0f;
        }

        public void NormalMotion()
        {
            StartCoroutine(SpeedNormalize());
        }

        public IEnumerator SpeedNormalize()
        {
            while (Time.timeScale != 1f)
            {
                Time.timeScale += 0.2f;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}