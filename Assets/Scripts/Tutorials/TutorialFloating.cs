using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFloating : MonoBehaviour
{
    public float speedUpDown = 1;
    public float distanceUpDown = 1;

    float defaultY;

    private void Start()
    {
        defaultY = transform.localPosition.y;
    }

    void Update()
    {
        Vector3 mov = new Vector3(transform.localPosition.x, defaultY + (Mathf.Sin(speedUpDown * Time.time) * distanceUpDown), transform.localPosition.z);
        transform.localPosition = mov;
    }
}
