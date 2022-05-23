using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereNotGravity : MonoBehaviour
{
    private void OnTriggerEnter(Collider Sphere)
    {
        Sphere.GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnTriggerExit(Collider Sphere)
    {
        Sphere.GetComponent<Rigidbody>().useGravity = true;
    }
}
