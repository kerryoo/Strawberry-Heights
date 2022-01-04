using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryPlayer : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    private bool toggleText = true;
    private string text = "";

    /*
     * For now, just rotate the player left and right when a and d are pressed
     * respectively.
     * 
     * Rotates the player camera up and down with w and s respectively.
     */
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(Vector3.down * speed, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(Vector3.up * speed, Space.Self);
        }

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Rotate(Vector3.left * speed, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Rotate(Vector3.right * speed, Space.Self);
        }
    }

    void FixedUpdate()
    {
        bool hit = Physics.Raycast(transform.position, transform.forward, out _, 5, 1 << 3);

        // Does the ray intersect any objects in the customers layer
        if (hit && text.Length == 0)
        {
            // (TODO) create NPC dialog for a random order
            text = "I would like a cube and sphere cake!";
        }
        else if (!hit && text.Length > 0)
        {
            text = "";
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 250, 20), text);
    }
}
