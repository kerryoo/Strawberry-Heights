using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector2 MouseInput;
    public float Vertical;
    public float Horizontal;
    public bool Interact;
    public bool TestButton;
    public bool Up;
    public bool Down;

    private void Update()
    {
        MouseInput.x = Input.GetAxisRaw("Mouse X");
        MouseInput.y = Input.GetAxisRaw("Mouse Y");
        TestButton = Input.GetKeyDown(KeyCode.P);
        Interact = Input.GetMouseButtonDown(0);
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        Up = Input.GetKey(KeyCode.Space);
        Down = Input.GetKey(KeyCode.LeftShift);
    }
}
