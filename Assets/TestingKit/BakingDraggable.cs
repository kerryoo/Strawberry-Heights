using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakingDraggable : MonoBehaviour
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
            transform.position = rayPoint;

            if (Input.GetKey(KeyCode.Q))
            {
                Vector3 rotation = new Vector3(0, 60f, 0) * Time.deltaTime;
                transform.Rotate(rotation, Space.Self);
            }
            if (Input.GetKey(KeyCode.E))
            {
                Vector3 rotation = new Vector3(0, -60f, 0) * Time.deltaTime;
                transform.Rotate(rotation, Space.Self);
            }
        }
    }
}