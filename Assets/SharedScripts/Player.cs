using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] InputController inputController;
    [SerializeField] Animator animator;
    [SerializeField] Camera camera;

    [SerializeField] float moveSpeed = 0.66f;
    [SerializeField] float mouseSensitivity = 200f;
    [SerializeField] float backwardsMoveScale = 0.66f;
    [SerializeField] float interpolationScale = 10f;
    

    private float currentVertical = 0f;
    private float currentHorizontal = 0f;

    void Update()
    {
        Move();
        
    }

    void Move()
    {
        float forwardInput = inputController.Vertical;
        float rightInput = inputController.Horizontal;

        if (forwardInput < 0)
        {
            forwardInput *= backwardsMoveScale;
        }

        currentVertical = Mathf.Lerp(currentVertical, forwardInput, Time.deltaTime * interpolationScale);
        currentHorizontal = Mathf.Lerp(currentHorizontal, rightInput, Time.deltaTime * interpolationScale);

        transform.position += transform.forward * currentVertical * moveSpeed * Time.deltaTime;
        transform.Rotate(0, currentHorizontal * mouseSensitivity * Time.deltaTime, 0);

        transform.Rotate(0, inputController.MouseInput.x * mouseSensitivity * Time.deltaTime, 0);

        if (camera.transform.rotation.eulerAngles.x < -30)
        {
            camera.transform.rotation = Quaternion.Euler(-30, 0, 0);
        }
        if (camera.transform.rotation.eulerAngles.x > 30)
        {
            camera.transform.rotation = Quaternion.Euler(30, 0, 0);
        }

        camera.transform.Rotate(-inputController.MouseInput.y * mouseSensitivity * Time.deltaTime, 0, 0);

        animator.SetFloat("MoveSpeed", currentVertical);
    }

    void MoveCamera()
    {

    }
}
