using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sharpnessZoom; //�������� ����
    [SerializeField] private float cameraPosition; //������� ��� ������ ��� �������
    [SerializeField] private int cameraZoomMax; //������������ �����������
    [SerializeField] private int cameraZoomMin; //���������
    [SerializeField] private float cameraSpeed; // �������� ������
    [SerializeField] private RaycastHit hit;
    //[SerializeField] private MouseState MS;
    
    private void Start()
    {
        //MS = gameObject.GetComponent<MouseState>();
    }

    private void FixedUpdate()
    {
        CameraMeightPosition();
        CameraWidthPosition();
    }

    private void CameraWidthPosition()
    {
        Vector3 directionRay = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, directionRay, out hit, 100)); //������ ����������� �������� 
        {
            if (hit.collider.tag == "ground")
            {
                if (hit.distance < cameraPosition) //���� ��������� �� ����� ������ ��� CameraPosition
                {
                    transform.position += new Vector3(0, cameraPosition - hit.distance, 0); // ���������� � ����� ������� �������
                }
                if (hit.distance > cameraPosition)
                {
                    transform.position -= new Vector3(0, hit.distance - cameraPosition, 0);
                }
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0 && cameraPosition < cameraZoomMin) //���� ������� �������� ���� �� ����, ���� n � ������� ���������
        {
            cameraPosition += 2 * sharpnessZoom * Time.deltaTime; //����������� ������ ����� CameraPosition
            cameraSpeed += 0.007f; //�������� �������� ����������� ������
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && cameraPosition > cameraZoomMin) //���� ������� �������� ���� �� ����, ���� n � ������� ���������
        {
            cameraPosition -= 2 * sharpnessZoom * Time.deltaTime; //��������� ������ ����� CameraPosition
            cameraSpeed -= 0.007f; //�������� �������� ����������� ������
        }
    }

    private void CameraMeightPosition()
    {
            if (20 > Input.mousePosition.x)
            {
                transform.position -= new Vector3(cameraSpeed, 0, 0);
            }
            if ((Screen.width - 10) < Input.mousePosition.x)
            {
                transform.position += new Vector3(cameraSpeed, 0, 0);
            }
            if (20 > Input.mousePosition.y)
            {
                transform.position -= new Vector3(0, 0, cameraSpeed);
            }
            if ((Screen.height - 10) < Input.mousePosition.y)
            {
                transform.position += new Vector3(0, 0, cameraSpeed);
            }
    }
}
