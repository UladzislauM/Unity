using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorRTS : MonoBehaviour
{
    [SerializeField] Texture selectTexture;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 mouseStartPosition;
    private float mouseX;
    private float mouseY;
    private float selectionHeight;
    private float selectionWidth;
    private Vector3 selectionStartPoint;
    private Vector3 selectionEndPoint;
    private bool selecting;
    private ResControl resurces;

    private void Start()
    {
        resurces = GetComponent<ResControl>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selecting = true;
            mouseStartPosition = Input.mousePosition;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                selectionStartPoint = hit.point;
            }

        }

        mouseX = Input.mousePosition.x;
        mouseY = Screen.height - Input.mousePosition.y;
        selectionWidth = mouseStartPosition.x - mouseX;
        selectionHeight = Input.mousePosition.y - mouseStartPosition.y;

        if (Input.GetMouseButtonUp(0))
        {
            selecting = false;
            DecelectAll();

            //if (mouseStartPosition == Input.mousePosition)
            //{
            //    //SingleSelect();
            //}
            //else
            //{
            //    MultiSelect();
            //}
        }
    }

    private void MultiSelect()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            selectionEndPoint = hit.point;
        }
        SelectHightLighted();
    }

    private void OnGUI()
    {
        if (selecting)
        {
            GUI.DrawTexture(new Rect(mouseX, mouseY, selectionWidth, selectionHeight), selectTexture);
        }
    }

    private void SelectHightLighted()
    {
        foreach(GameObject unit in resurces.units)
        {
            float x = unit.transform.position.x;
            float y = unit.transform.position.y;

            if ((x> selectionStartPoint.x && x< selectionEndPoint.x)
                || (x< selectionStartPoint.x && x> selectionEndPoint.x))
            {
                if((y> selectionStartPoint.y && y< selectionEndPoint.y) 
                    || (y< selectionStartPoint.y && y> selectionEndPoint.y))
                {
                    Debug.Log("eeeee");
                    unit.GetComponent<UnitControl>().isSelected = true;
                }
            }
        }
    }

    //private void SingleSelect()
    //{
    //    if (hit.collider.gameObject.CompareTag("Player"))
    //    {
    //        hit.collider.gameObject.GetComponent<UnitControl>().isSelected = true;
    //    }
    //}

    private void DecelectAll()
    {
        foreach (GameObject unit in resurces.units)
        {
            unit.GetComponent<UnitControl>().isSelected = false;
        }
    }
}
