using System.Collections;
using TMPro;
using UnityEngine;

namespace UI_Scripts
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private TextMeshProUGUI scoreTracker;

        private void Update()
        {
            scoreTracker.text = playerTransform.position.z.ToString("0");
        }

        public IEnumerator TextFade()
        {
            for (var i = 70; i < 130; i += 5)
            {
                scoreTracker.fontSize = i;
                yield return new WaitForSeconds(0.00001f);
            }
        }
    }
}