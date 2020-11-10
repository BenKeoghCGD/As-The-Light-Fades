using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class splashHandler : MonoBehaviour
{
    public List<Sprite> Logos = new List<Sprite>();

    [Tooltip("The amount of time taken for the image to fade in and out.")] public float fadeTime;
    [Tooltip("Amount of time between fades")] public float fadeDelay;

    public Canvas SplashScreen;
    public Color defColour = new Color(255, 255, 255, 0);
    public Image SplashLogo;

    public Camera bg;

    [Header("Bounds")]
    public float amplitude_piv;
    public float frontBound;
    public float backBound;

    [Header("Attributes")]
    [Range(0, 10)] public float speed_cam;
    [Range(0, 10)] public float speed_piv;

    public Canvas MainMenu;
    public Canvas options;

    private void Start()
    {
        options.enabled = false;
        MainMenu.enabled = false;
        SplashLogo.color = new Color(255, 255, 255, 0);
        StartCoroutine(Loop());
    }

    private void FixedUpdate()
    {
        bg.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Sin(Time.time * speed_piv) * amplitude_piv);

        bg.transform.localPosition = new Vector3(-74.1f, 111.6f, backBound + Mathf.PingPong(Time.time * speed_cam, frontBound - backBound));
    }

    public IEnumerator Loop()
    {
        foreach(Sprite s in Logos)
        {
            SplashLogo.sprite = s;
            yield return new WaitForSeconds(fadeDelay);
            for (float i = 0; i <= 1; i += (fadeTime * Time.deltaTime))
            {
                SplashLogo.color = new Color(defColour.r, defColour.g, defColour.b, i);
                yield return null;
            }
            yield return new WaitForSeconds(fadeDelay);
            for (float i = 1; i >= 0; i -= (fadeTime * Time.deltaTime))
            {
                SplashLogo.color = new Color(defColour.r, defColour.g, defColour.b, i);
                yield return null;
            }
            SplashLogo.color = new Color(defColour.r, defColour.g, defColour.b, 0);
            yield return null;
        }
        SplashScreen.enabled = false;
        StartCoroutine(showMM());
    }

    public IEnumerator showMM()
    {
        yield return null;
        MainMenu.enabled = true;
    }
}
