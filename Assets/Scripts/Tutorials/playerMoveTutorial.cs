using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveTutorial : MonoBehaviour
{
    private GameObject player;
    private Rigidbody player_rb;

    [Header("Movement Values")]
    [Tooltip("Vertical speed of camera")] public float speedV = 2.0f;
    private float pitch = 0.0f;

    [Tooltip("Horizontal speed of camera")] public float speedH = 2.0f;
    private float yaw = 0.0f;

    private bool isGrounded;
    [Tooltip("Height of jump")] public float jumpForce = 5.0f;
    [Tooltip("Speed along X Axis")] public float xSpeed = 5.0f;
    [Tooltip("Speed along Z Axis")] public float zSpeed = 5.0f;

    private float xSpeedA;
    private float zSpeedA;

    [Header("Tutorial Items")]
    public Canvas Look_Tutorial;

    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        xSpeedA = xSpeed;
        zSpeedA = zSpeed;

        player = this.gameObject;
        player_rb = player.GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isGrounded = true;
    }

    void Update()
    {
        //MOVEMENT
        if (Input.GetKey(KeyCode.W)) transform.position += transform.forward * (0.01f * zSpeedA);
        if (Input.GetKey(KeyCode.S)) transform.position += transform.forward * (-0.01f * zSpeedA);
        if (Input.GetKey(KeyCode.A)) transform.position += transform.right * (-0.01f * xSpeedA);
        if (Input.GetKey(KeyCode.D)) transform.position += transform.right * (0.01f * xSpeedA);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) transform.GetChild(0).transform.localPosition = new Vector3(0, 0.61f + Mathf.PingPong(Time.time, 0.2f), 0);
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) player_rb.velocity = Vector3.zero;
        else transform.GetChild(0).transform.localPosition = new Vector3(0, 0.61f, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            player_rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftControl)) GetComponent<CapsuleCollider>().height = 1;
        else GetComponent<CapsuleCollider>().height = 2;

        //CAMERA
        if (!Cursor.visible)
        {
            pitch -= speedV * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -75f, 75f);
            transform.GetChild(0).transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);

            yaw += speedH * Input.GetAxis("Mouse X");
            transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        }

        //TORCH
        if (Input.GetKeyDown(KeyCode.F)) transform.GetChild(0).transform.GetChild(0).GetComponent<Light>().enabled = !transform.GetChild(0).transform.GetChild(0).GetComponent<Light>().enabled;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "floor") isGrounded = true;
    }
}
