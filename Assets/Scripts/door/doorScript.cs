using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    float startRotation;

    [Header("Variables")]
    public bool openOut;
    public bool locked;

    [Header("If Locked")]
    public raycast.KeyCards KeyCard;

    bool doorStatus = false;
    bool doorGo;

    float doorAnimSpeed = 0.2f;

    bool looking;

    private void Start()
    {
        transform.localEulerAngles = new Vector3(-90,0,startRotation);
        startRotation = transform.localEulerAngles.z;
    }

    private void FixedUpdate()
    {
        if (doorStatus)
        {
            /*if (openOut)*/ transform.localEulerAngles.Set(transform.localEulerAngles.x, transform.localEulerAngles.y, 90);
            //else transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, startRotation - 90);
        }
        else transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, startRotation);
    }

    public void Toggle(List<raycast.KeyCards> cards)
    {
        if (locked && cards.Contains(KeyCard)) doorStatus = !doorStatus;
        else if (!locked) doorStatus = !doorStatus;
    }


    public IEnumerator moveDoor(Quaternion dest)
    {
        doorGo = true;
        while (Quaternion.Angle(transform.localRotation, dest) > 4.0f)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, dest, Time.deltaTime * doorAnimSpeed);
            yield return null;
        }
        doorStatus = !doorStatus;
        doorGo = false;
        yield return null;
    }

    internal void isLooking(List<raycast.KeyCards> obtainedKeycards)
    {
        looking = true;
    }
}
