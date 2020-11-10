using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsHandler : MonoBehaviour
{
    int scene = 0;

    [Header("GAME SCENE")]
    public Text fpsCounter;

    [Header("SETTINGS SCENE")]
    public Toggle ShowFPS;
    public Toggle Mute;
    public Slider Vol;
    public Slider Sensitivity;

    private void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if(scene == SceneManager.GetSceneByName("Game").buildIndex)
        {
            fpsCounter.enabled = Settings.ShowFPS;
            AudioListener.volume = Settings.Volume;
        }
        else if(scene == SceneManager.GetSceneByName("MainMenu").buildIndex)
        {
            Settings.ShowFPS = ShowFPS.isOn;
            Settings.Volume = Mute.isOn ? 0 : Vol.value / 100;
            Settings.Sensitivity = (int) Sensitivity.value;
        }
    }
}
