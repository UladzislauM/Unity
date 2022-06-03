using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBox : MonoBehaviour
{
    private Vector2 targetPosition;
    private bool mouseEnter = true;
    [SerializeField] private Transform tr_body;
    [SerializeField] private List<Transform> db_moves;
    [SerializeField] private float rotate_speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //при нажатии правой кнопкой мыши нажимается только по поверхности земли
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                mouseEnter = true;
                targetPosition = hit.point;
                Debug.Log(hit.point);
            }
        }
        if (mouseEnter)
        {
            Vector3 tar_dir = /*db_moves[1].position - */tr_body.position;
            Vector3 new_dir = Vector3.RotateTowards(tr_body.forward, tar_dir, rotate_speed * Time.deltaTime / 2, 0f);
            new_dir.y = 0;
            tr_body.transform.rotation = Quaternion.LookRotation(new_dir);
        }
    }
}
