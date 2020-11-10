using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockPush : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            if (transform.position.x > collision.gameObject.transform.position.x) transform.position += new Vector3(3f, 0f, 0f);
            if (transform.position.x < collision.gameObject.transform.position.x) transform.position -= new Vector3(3f, 0f, 0f);
            if (transform.position.z > collision.gameObject.transform.position.z) transform.position += new Vector3(0f, 0f, 3f);
            if (transform.position.z < collision.gameObject.transform.position.z) transform.position -= new Vector3(0f, 0f, 3f);
        }
    }
}
