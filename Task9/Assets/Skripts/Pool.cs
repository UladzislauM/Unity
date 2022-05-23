using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pool : MonoBehaviour
{
    [SerializeField] private float timeToStart;
    [SerializeField] private float powerBall;
    [SerializeField] private Rigidbody ball;

    private void Start()
    {
            ball.AddForce(powerBall, 0, 0, ForceMode.Impulse);
    }
}
