using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{

    public Canvas mainMenu;
    public Canvas options;

    void Start()
    {
        options.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        if(this.GetComponent<Canvas>().enabled == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnOptions()
    {
        mainMenu.enabled = false;
        options.enabled = true;
    }

    public void OnMain()
    {
        mainMenu.enabled = true;
        options.enabled = false;
    }

    public void onQuit()
    {
        Application.Quit();
    }
}
