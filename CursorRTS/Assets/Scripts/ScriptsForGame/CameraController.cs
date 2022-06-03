using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sharpnessZoom; //Скорость зума
    [SerializeField] private float cameraPosition; //Позиция над точкой под камерой
    [SerializeField] private int cameraZoomMax; //максимальное приблежение
    [SerializeField] private int cameraZoomMin; //отдаление
    [SerializeField] private float cameraSpeed; // Скорость камеры
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
        if (Physics.Raycast(transform.position, directionRay, out hit, 100)); //задаем направление рейкаста 
        {
            if (hit.collider.tag == "ground")
            {
                if (hit.distance < cameraPosition) //Если дистанция до земли меньше чем CameraPosition
                {
                    transform.position += new Vector3(0, cameraPosition - hit.distance, 0); // прибавляем к нашей позиции разницу
                }
                if (hit.distance > cameraPosition)
                {
                    transform.position -= new Vector3(0, hit.distance - cameraPosition, 0);
                }
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0 && cameraPosition < cameraZoomMin) //если двинули колёсиком мыши на себя, если n в пределе отдаления
        {
            cameraPosition += 2 * sharpnessZoom * Time.deltaTime; //Приблежение высоты через CameraPosition
            cameraSpeed += 0.007f; //повышаем скорость перемещения камеры
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && cameraPosition > cameraZoomMin) //если двинули колёсиком мыши на себя, если n в пределе отдаления
        {
            cameraPosition -= 2 * sharpnessZoom * Time.deltaTime; //Отдаление высоты через CameraPosition
            cameraSpeed -= 0.007f; //понижаем скорость перемещения камеры
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
