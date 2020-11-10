using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorialHandler : MonoBehaviour
{
    [Header("Tutorial Canvas Items")]
    public Canvas Tutorial_Canvas;
    public Text Tutorial_Text;
    public Image Tutorial_Progress;
    public Image Tutorial_Progress2;
    public Text Tutorial_Completed;
    public Canvas Tutorial_Over;

    [Header("Progress Images")]
    public Sprite Progress_InProgress;
    public Sprite Progress_Done;

    [Range(0,100)] public float Progress_Amount = 0;

    public int tutorial = 0;

    [Header("Animation Items")]
    public playerMoveTutorial player;
    public Camera cam;
    public GameObject note;

    void Start()
    {
        Tutorial_Over.enabled = false;
        Tutorial_Canvas.enabled = true;
        Tutorial_Progress.fillAmount = 0;
        Tutorial_Progress2.fillAmount = 0;
        Tutorial_Text.rectTransform.localPosition = new Vector2(-2000f, 0f);

        cam.transform.localPosition = new Vector3(0.505f, 0.398f, -0.64f);
        cam.transform.localEulerAngles = new Vector3(0, 0, 0);

        note.transform.localPosition = new Vector3(2.999997f, 1.120025f, -0.5599709f);
        note.transform.localEulerAngles = new Vector3(0f, 24.651f, 0f);
    }

    Vector3 lastMousePosition = Vector3.zero;
    Vector3 lastPosition = Vector3.zero;

    bool crouch_down = false;
    bool crouch_up = false;

    bool changing = false;

    bool anim = false;

    bool done = false;

    void FixedUpdate()
    {
        if (done && Input.GetKeyDown(KeyCode.Space)) changeScene();
        if(!anim)
        {
            switch (tutorial)
            {
                case 0: // MOUSE
                    Tutorial_Text.text = "MOVE YOUR MOUSE TO LOOK AROUND";
                    if (Input.mousePosition != lastMousePosition) Progress_Amount += 5f;
                    lastMousePosition = Input.mousePosition;
                    break;

                case 1: // WALK
                    Tutorial_Text.text = "USE 'W', 'A', 'S' AND 'D' TO MOVE AROUND";
                    if (transform.position != lastPosition) Progress_Amount += 1f;
                    lastPosition = transform.position;
                    break;

                case 2: // JUMP
                    Tutorial_Text.text = "USE 'SPACEBAR' TO JUMP";
                    if (Input.GetKeyDown(KeyCode.Space)) Progress_Amount += 34f;
                    break;

                case 3: // CROUCH
                    Tutorial_Text.text = "USE 'LEFT CONTROL' TO CROUCH";
                    if (Input.GetKeyDown(KeyCode.LeftControl)) crouch_down = true;
                    if (Input.GetKeyUp(KeyCode.LeftControl)) crouch_up = true;
                    if (crouch_down && crouch_up) Progress_Amount = 105f;
                    else if (crouch_down || crouch_up) Progress_Amount = 50f;
                    break;

                case 4: // TORCH
                    Tutorial_Text.text = "USE 'F' TO TOGGLE FLASHLIGHT";
                    if (Input.GetKeyDown(KeyCode.F)) Progress_Amount += 51f;
                    break;

                case 5: // ENDING
                    Tutorial_Progress.enabled = false;
                    Tutorial_Progress2.enabled = false;
                    Tutorial_Text.enabled = false;
                    Tutorial_Completed.enabled = true;
                    StartCoroutine(beginAnim());
                    break;
            }

            Tutorial_Progress.fillAmount = Mathf.Lerp(Tutorial_Progress.fillAmount, Progress_Amount / 100, Time.deltaTime * 2);
            Tutorial_Progress2.fillAmount = Mathf.Lerp(Tutorial_Progress.fillAmount, Progress_Amount / 100, Time.deltaTime * 50);
            Tutorial_Text.rectTransform.localPosition = new Vector2(Mathf.Lerp(Tutorial_Text.rectTransform.localPosition.x, -730f, Time.deltaTime * 2), 0f);

            if (Tutorial_Progress.fillAmount >= 1f && !changing) StartCoroutine(delayTut());
        }
    }



    private IEnumerator beginAnim()
    {
        anim = true;
        Vector3 note_defaultRotation = note.transform.localEulerAngles;
        player.enabled = false;
        yield return new WaitForSeconds(3);
        while (cam.transform.localPosition != new Vector3(0.505f, 0.61f, -3.064f))
        {
            yield return new WaitForSeconds(0.001f);
            cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(0.505f, 0.61f, -3.064f), Time.deltaTime * 2);
        }
        while (cam.transform.localPosition != new Vector3(1.07f, 0.4600008f, -1.41f) && cam.transform.localEulerAngles != new Vector3(7.152f, 24.651f, 0f))
        {
            yield return new WaitForSeconds(0.001f);
            cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(1.07f, 0.4600008f, -1.41f), Time.deltaTime * 5);
            cam.transform.localEulerAngles = Vector3.Lerp(cam.transform.localEulerAngles, new Vector3(7.152f, 24.651f, 0f), Time.deltaTime * 2);
        }
        note.GetComponent<Animation>().Play();
        while (note.GetComponent<Animation>().isPlaying)
        {
            yield return new WaitForSeconds(0.001f);
        }
        Tutorial_Over.enabled = true;
        done = true;
    }

    public IEnumerator delayTut()
    {
        changing = true;
        Tutorial_Progress.sprite = Progress_Done;
        Tutorial_Progress.fillAmount = 1f;
        Tutorial_Progress2.sprite = Progress_Done;
        Tutorial_Progress2.fillAmount = 1f;
        yield return new WaitForSeconds(3f);
        Tutorial_Progress.sprite = Progress_InProgress;
        Tutorial_Progress2.sprite = Progress_InProgress;
        tutorial++;
        Tutorial_Text.rectTransform.localPosition = new Vector2(-2000f, 0f);
        Progress_Amount = 0f;
        changing = false;
    }

    public void changeScene()
    {
        SceneManager.LoadScene(2);
    }
}
