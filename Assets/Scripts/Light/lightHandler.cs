using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightHandler : MonoBehaviour
{
    [HideInInspector] public GameObject player;

    void Start()
    {
        player = gameObject;
        StartCoroutine(getClosestLight());
    }

    public float lowest = 0;
    public GameObject lowestLight;

    private IEnumerator getClosestLight()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(0.0001f);
            object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
            foreach(object o in obj)
            {
                GameObject g = (GameObject) o;
                if(g.GetComponent<Light>() != null)
                {
                    if (g.GetComponent<Light>().enabled == true)
                    {
                        lowest = Vector3.Distance(transform.position, g.transform.position);
                        lowestLight = g;
                    }
                }
            }
        }
    }
}
