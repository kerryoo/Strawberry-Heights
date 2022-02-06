using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool dragging = false;
    private float distance;

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            Vector3 lockedRayPoint = rayPoint;
            rayPoint.y = transform.position.y;
            transform.position = rayPoint;

            if (Input.GetKey(KeyCode.E))
            {
                Vector3 rotation = new Vector3(0, 90f, 0) * Time.deltaTime;
                transform.Rotate(rotation, Space.Self);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                Vector3 rotation = new Vector3(0, -90f, 0) * Time.deltaTime;
                transform.Rotate(rotation, Space.Self);
            }
        }
    }
}
