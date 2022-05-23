using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private float timeToExp;
    [SerializeField] private float power;
    [SerializeField] private float radius;

    private void Update()
    {
        timeToExp -= Time.deltaTime;
        if (timeToExp <= 0)
        {
            Explosion();
        }
    }

    private void Explosion()
    {
        Rigidbody[] cubes = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody b in cubes)
        {
            float distExp = Vector3.Distance(transform.position, b.transform.position);

            if (Vector3.Distance(transform.position, b.transform.position) < radius)
            {
                Vector3 direction = b.transform.position - transform.position;

                b.AddForce(direction.normalized * power * (radius - distExp), ForceMode.Impulse);
            }
        }
        timeToExp = 3;
    }
}
