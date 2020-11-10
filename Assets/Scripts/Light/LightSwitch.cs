using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [Header("Lights")]
    public List<Light> lights = new List<Light>();
    private bool on = false;

    void Start()
    {

    }
    private void OnTriggerStay(Collider plyr)
    {
        if (plyr.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !on)
        {
            foreach (Light light in lights)
            {
                light.enabled = true;
            }
            on = true;
        }
        else if (plyr.tag == "Player" && Input.GetKeyDown(KeyCode.E) && on)
        {
            foreach (Light light in lights)
            {
                light.enabled = false;
            }
            on = false;
        }
    }
}
