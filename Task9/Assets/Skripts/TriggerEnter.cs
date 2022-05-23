using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEnter : MonoBehaviour
{
    [SerializeField] private Text poolRes;
    private int numResoult;

    private void Start()
    {
        numResoult = 0;
    }

    private void OnTriggerEnter(Collider OBJ)
    {
        if (OBJ.gameObject.layer == 9 || OBJ.gameObject.layer == 10 || OBJ.gameObject.layer == 11)
        {
            numResoult++;
            poolRes.text = numResoult.ToString();
        }
    }
}
