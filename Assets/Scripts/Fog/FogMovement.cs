using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FogMovement : MonoBehaviour
{
    public float lowest = 99999999999999999999999999999f;
    public GameObject lowestLight;
    public float speed = 2;
    public float radius = 30;

    NavMeshAgent Agent;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    List<GameObject> Priority_Highest = new List<GameObject>(); // = 128
    List<GameObject> Priority_High = new List<GameObject>(); // = 96
    List<GameObject> Priority_Normal = new List<GameObject>(); // = 64
    List<GameObject> Priority_Low = new List<GameObject>(); // = 32
    List<GameObject> Priority_Lowest = new List<GameObject>(); // = 0
    List<GameObject> Priority_Deter = new List<GameObject>(); // = -32

    int inRadius = 0;

    void Update()
    {
        Priority_Highest.Clear();
        Priority_High.Clear();
        Priority_Normal.Clear();
        Priority_Low.Clear();
        Priority_Lowest.Clear();
        Priority_Deter.Clear();

        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));

        foreach(GameObject o in obj)
        {
            if(Vector3.Distance(transform.position, o.transform.position) < radius && o.GetComponent<Light>() != null && o.GetComponent<lightReference>().Consumed == false)
            {
                inRadius++; 
                if(o.tag.Equals("Light_Priority_Highest")) Priority_Highest.Add(o);
                else if(o.tag.Equals("Light_Priority_High")) Priority_High.Add(o);
                else if(o.tag.Equals("Light_Priority_Normal")) Priority_Normal.Add(o); 
                else if(o.tag.Equals("Light_Priority_Low")) Priority_Low.Add(o);
                else if(o.tag.Equals("Light_Priority_Lowest")) Priority_Lowest.Add(o);
                else if(o.tag.Equals("Light_Priority_Deter")) Priority_Deter.Add(o); 
            }
        }

        if(Priority_Highest.Count > 0) foreach(GameObject o in Priority_Highest)
            {
                if (lowest > Vector3.Distance(transform.position, o.transform.position))
                {
                    lowest = Vector3.Distance(transform.position, o.transform.position);
                    lowestLight = o;
                }
            }
        else if (Priority_High.Count > 0) foreach (GameObject o in Priority_High)
            {
                if (lowest > Vector3.Distance(transform.position, o.transform.position))
                {
                    lowest = Vector3.Distance(transform.position, o.transform.position);
                    lowestLight = o;
                }
            }
        else if (Priority_Normal.Count > 0) foreach (GameObject o in Priority_Normal)
            {
                if (lowest > Vector3.Distance(transform.position, o.transform.position))
                {
                    lowest = Vector3.Distance(transform.position, o.transform.position);
                    lowestLight = o;
                }
            }
        else if (Priority_Low.Count > 0) foreach (GameObject o in Priority_Low)
            {
                if (lowest > Vector3.Distance(transform.position, o.transform.position))
                {
                    lowest = Vector3.Distance(transform.position, o.transform.position);
                    lowestLight = o;
                }
            }
        else if (Priority_Lowest.Count > 0) foreach (GameObject o in Priority_Lowest)
            {
                if (lowest > Vector3.Distance(transform.position, o.transform.position))
                {
                    lowest = Vector3.Distance(transform.position, o.transform.position);
                    lowestLight = o;
                }
            }

        inRadius = 0;
        Agent.SetDestination(lowestLight.transform.position);
        if (Vector3.Distance(transform.position, lowestLight.transform.position) < 10)
        {
            lowest = 9999999999999999999;
            lowestLight.GetComponent<lightReference>().Consumed = true;
        }
    }
}