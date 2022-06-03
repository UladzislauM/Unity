using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMuvement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool useCamera;
    [SerializeField, Range(-100, 100)] private float endCameraXMin;
    [SerializeField, Range(-100, 100)] private float endCameraXMax;
    [SerializeField, Range(-100, 100)] private float endCameraYMin;
    [SerializeField, Range(-100, 100)] private float endCameraYMax;

    private int screenWidth;
    private int screenHeight;



    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = transform.position;

        if (Input.mousePosition.x <= 20)
        {
            camPos.x -= Time.deltaTime * speed;
        }
        else if (Input.mousePosition.x >= screenWidth - 20)
        {
            camPos.x += Time.deltaTime * speed;
        }
        else if (Input.mousePosition.y <= 20)
        {
            camPos.y -= Time.deltaTime * speed;
        }
        else if (Input.mousePosition.y >= screenWidth - 20)
        {
            camPos.y += Time.deltaTime * speed;
        }
        if (useCamera)
        {
            transform.position = new Vector3(Mathf.Clamp(camPos.x, endCameraXMin, endCameraXMax), Mathf.Clamp(camPos.y, endCameraYMin, endCameraYMax));
        }
    }
}
