using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleRun : MonoBehaviour
{
    [SerializeField] private Transform[] runners;
    [SerializeField] private GameObject baton;
    [SerializeField] private float speed;
    private int nowPoint;
    private Vector3 rPositionNow;
    private Vector3 rPositionNext;
    private float indexTime;
    private int nextPoint;

    private void Start()
    {
        baton.transform.SetParent(runners[nowPoint]);
    }

    private void Update()
    {
        nextPoint = NextIndex(nowPoint);
        rPositionNow = runners[nowPoint].position;
        rPositionNext = runners[nextPoint].position;
        indexTime = Time.deltaTime * speed;

        runners[nowPoint].position = Vector3.MoveTowards(rPositionNow, rPositionNext, indexTime);

        if (Vector3.Distance(rPositionNow, rPositionNext) < 0.01f)
        {
            nowPoint = nextPoint;
            nextPoint = NextIndex(nowPoint);
            runners[nowPoint].LookAt(runners[nextPoint]);
            baton.transform.SetParent(runners[nowPoint], false);
        }
    }

    private int NextIndex(int index)
    {
        index++;
        if (index < runners.Length)
        {
            return index;
        }
        else
        {
            return 0;
        }
    }
}
