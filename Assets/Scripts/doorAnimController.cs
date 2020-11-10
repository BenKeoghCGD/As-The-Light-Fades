using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnimController : MonoBehaviour
{
    public bool doorOpen = false;
    public float defaultRotation;
    public bool openOut = false;
    public float doorSpeed = 2;

    private void Update()
    {
        if (doorOpen) transform.eulerAngles = new Vector3(-90f, 0, Mathf.Lerp(transform.eulerAngles.z, openOut ? defaultRotation - 90 : defaultRotation + 90, Time.time * doorSpeed));
        else transform.eulerAngles = new Vector3(-90f, 0, Mathf.Lerp(transform.eulerAngles.z, defaultRotation, Time.time * doorSpeed));
        //Debug.Log(Time.time);


    }
}
