using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private Text _checkText;
    private int _check;
    private Collider _tagCheck;

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "NotTriggerCollider" 
            && _tagCheck != trigger)
        {
            _check++;
            _checkText.text = _check.ToString();
            _tagCheck = trigger;
        }
        if (trigger.gameObject.tag == "ResetTrigger")
        {
            _tagCheck = null;
            Debug.Log(_tagCheck);
        }
    }
}
