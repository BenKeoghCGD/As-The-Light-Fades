using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_Lists : MonoBehaviour
{
    [Header("Lights")]
    public List<Light> lights = new List<Light>(); // assign all lights within a single list

    private void Update()
    {
        foreach (Light light in lights) // Iterate through all light gameobjects inside the "lights" list
        {
            // control lights
        }
    }
}
