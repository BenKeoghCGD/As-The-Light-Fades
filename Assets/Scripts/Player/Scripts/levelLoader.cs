using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Level : System.Object
{
    public GameObject Level_GameObject;
    public GameObject Level_Elevator;
    public GameObject Level_Elevator_Button;
    public Vector3 Level_TeleportLocation;
    public bool Level_Default = false;
}

public class levelLoader : MonoBehaviour
{

    [Header("Defaults")]
    public List<Level> Levels;
    public Canvas LoadingScreen;
    public Image LoadingIcon;

    private int activeLevels = 0;
    private int activelevel = 0;
    void Start()
    {
        foreach(Level l in Levels)
        {
            Debug.Log("LOOPING FOR: " + l.Level_GameObject.name);
            if(l.Level_Default) activeLevels += 1; 
            else StartCoroutine(setActiveRecursively(l.Level_GameObject, false));
        }

        if(activeLevels != 1) Debug.LogError("NO ACTIVE LEVEL AND/OR TOO MANY ACTIVE LEVELS");

        LoadingScreen.enabled = false;
    }

    void Update()
    {
        LoadingIcon.transform.eulerAngles += new Vector3(0,0,5);

        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P");
            StartCoroutine(changeLevel(Random.Range(0,2)));
        }
    }

    public IEnumerator changeLevel(int level)
    {
        Debug.Log("INITIATED FOR LEVEL " + level);
        LoadingScreen.enabled = true;
        yield return setActiveRecursively(Levels[level].Level_GameObject, true);
        if(activelevel == 0) switch(level)
            {
                case 0: // HUB
                    break;

                case 1: // LEVEL 1
                    transform.position = new Vector3(transform.position.x, 30.99897f, transform.position.z);
                    break;

                case 2: // LEVEL 2
                    transform.position = new Vector3(transform.position.x, 17.92897f, transform.position.z);
                    break;
            }
        else if (activelevel == 1) switch(level)
            {
                case 0: // HUB
                    transform.position = new Vector3(transform.position.x, 43.51492f, transform.position.z);
                    break;

                case 1: // LEVEL 1
                    break;

                case 2: // LEVEL 2
                    transform.position = new Vector3(transform.position.x, 17.92897f, transform.position.z);
                    break;

            }
        else switch (level)
            {
                case 0: // HUB
                    transform.position = new Vector3(transform.position.x, 43.51492f, transform.position.z);
                    break;

                case 1: // LEVEL 1
                    transform.position = new Vector3(transform.position.x, 30.99897f, transform.position.z);
                    break;

                case 2: // LEVEL 2
                    break;

            }
        Debug.Log("a");
        activelevel = level;
        Debug.Log("b");
        /*foreach (Level l in Levels)
        {
            Debug.Log("c/d/e");
            if (l != Levels[level]) yield return setActiveRecursively(l.Level_GameObject, false);
        }*/
        if (level != 0) Levels[0].Level_GameObject.SetActive(false);
        if (level != 1) Levels[1].Level_GameObject.SetActive(false);
        if (level != 2) Levels[2].Level_GameObject.SetActive(false);
        Debug.Log("f");
        LoadingScreen.enabled = false;
        Debug.Log("g");
        Levels[level].Level_Elevator_Button.GetComponent<ElevatorHandler>().openDoor();
    }

    public IEnumerator setActiveRecursively(GameObject obj, bool state)
    {
        obj.SetActive(state);
        foreach(Transform child in obj.transform) setActiveRecursively(obj, state);
        yield return null;
    }
}
