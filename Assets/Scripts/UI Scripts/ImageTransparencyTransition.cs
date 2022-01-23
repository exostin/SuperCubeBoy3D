using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageTransparencyTransition : MonoBehaviour
{
    private Color32 color;
    private Image image;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        color = image.color;
        StartCoroutine(LowerTheAlpha());
    }

    private IEnumerator LowerTheAlpha()
    {
        for (byte i = 255; i > 0; i -= 5)
        {
            color.a = i;
            image.color = color;
            yield return new WaitForSeconds(0.0000001f);
        }

        color.a = 0;
        image.color = color;
    }
}