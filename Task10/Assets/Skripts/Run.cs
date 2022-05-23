using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    [SerializeField] private Vector3[] points;
    [SerializeField] private float speed;
    private Vector3 purpose;
    private bool forward;
    private int nowPoint;

    private void Start()
    {
        purpose = points[0];
        nowPoint = 0;
        forward = true;
    }

    private void Update()
    {
        Going();

            transform.position = Vector3.MoveTowards(transform.position, purpose, Time.deltaTime * speed);
    }

    private void Going()
    {
        if (transform.position == purpose)
        {
            if (purpose == points[points.Length - 1])
            {
                forward = false;
            }

            if (forward)
            {
                purpose = points[++nowPoint];
            }
            else
            {
                purpose = points[--nowPoint];
                forward = true;
            }
        }
    }
}
