using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControl : MonoBehaviour
{
    [SerializeField] private float duraction;
    [SerializeField] private bool _isSelected;
    private Vector2 targetPosition;
    private bool isRunning;
    private Animator anim;

    public bool isSelected { get { return _isSelected; } set { _isSelected = value; } }

    private void Start()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        ResControl resurses = controller.GetComponent<ResControl>();
        resurses.NewUnit(gameObject);
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            Ray ray;
            RaycastHit hit;
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                isRunning = true;
                targetPosition = hit.point;
                Debug.Log(hit.point);
            }
        }

        if (isRunning && !Mathf.Approximately(transform.position.magnitude, targetPosition.magnitude))
        {
            //transform.LookAt(targetPosition);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 1 / (duraction * (Vector3.Distance(transform.position, targetPosition))));
        }
        else if (isRunning && Mathf.Approximately(transform.position.magnitude, targetPosition.magnitude))
        {
            isRunning = false;
        }
    }
}
