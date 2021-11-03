using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private float Vertical;
    private float Horizontal;
    private bool Interact;
    private Vector2 MouseInput;
    private bool TestButton;

    private void Update()
    {
        MouseInput.x = Input.GetAxisRaw("Mouse X");
        MouseInput.y = Input.GetAxisRaw("Mouse Y");
        TestButton = Input.GetKeyDown(KeyCode.P);
        Interact = Input.GetKeyDown(KeyCode.Space);
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
    }
}
