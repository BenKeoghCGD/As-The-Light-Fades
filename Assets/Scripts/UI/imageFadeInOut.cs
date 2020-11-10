using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageFadeInOut : MonoBehaviour {

    [Header("Objects")]
    public Text text;

    [Header("Values")]
    [Tooltip("The amount of time taken for the image to fade in and out.")] public float fadeTime;
    [Tooltip("Amount of time between fades")] public float fadeDelay;
    [Tooltip("Color of fading attribute")] public Color defColour;

    private void Start()
    {
        StartCoroutine(begin());
    }

    IEnumerator begin()
    {
        while(true)
        {

            yield return new WaitForSeconds(fadeDelay);
            for (float i = 1; i >= 0; i -= (fadeTime * Time.deltaTime))
            {
                text.color = new Color(defColour.r, defColour.g, defColour.b, i);
                yield return null;
            }
            yield return new WaitForSeconds(fadeDelay);
            for (float i = 0; i <= 1; i += (fadeTime * Time.deltaTime))
            {
                text.color = new Color(defColour.r, defColour.g, defColour.b, i);
                yield return null;
            }
            yield return null;
        }
    }

}
