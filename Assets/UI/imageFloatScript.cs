using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageFloatScript : MonoBehaviour {

    [Header("Values")]
    public float Speed;
    public float Distance;

    Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update () {
        transform.position = _startPosition + new Vector3(0.0f, Mathf.Sin(Time.time * Speed) * Distance, 0.0f);
    }
}
