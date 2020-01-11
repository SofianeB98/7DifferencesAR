using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 50.0f))
        {
            if(hit.collider != null)
                hit.transform.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
