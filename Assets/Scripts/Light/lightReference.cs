using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightReference : MonoBehaviour
{
    public bool Consumed = false;

    private void Update()
    {
        if (Consumed) GetComponent<Light>().enabled = false;
    }

    public void toggleLight()
    {
        Light l = this.GetComponent<Light>();
        if(!Consumed) l.enabled = !l.enabled;
    }
}
