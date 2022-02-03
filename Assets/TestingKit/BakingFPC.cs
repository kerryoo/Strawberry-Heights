using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakingFPC : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float moveSpeed = 4;
    [SerializeField] float turnSpeed = 200;

    private float currVertical = 0;
    private float currHorizontal = 0;

    [Range(0f, 90f)] [SerializeField] float yRotationLimit = 88f;

    private Vector2 rotation;

    void Start()
    {
        rotation = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Move();
    }

    private void Look()
    {
        rotation.x += Input.GetAxis("Mouse X") * 5;
        rotation.y += Input.GetAxis("Mouse Y") * 5;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat * yQuat;


    }

    private void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        currVertical = Mathf.Lerp(currVertical, vertical, Time.deltaTime * 10);
        currHorizontal = Mathf.Lerp(currHorizontal, horizontal, Time.deltaTime * 10);

        Vector3 clampedForwardVector = transform.forward;
        clampedForwardVector.y = 0;
        transform.position += clampedForwardVector * currVertical * moveSpeed * Time.deltaTime;
        transform.Rotate(0, currHorizontal * turnSpeed * Time.deltaTime, 0);


        if (Input.GetKey(KeyCode.E))
        {

        } else if (Input.GetKey(KeyCode.Q))
        {

        }
    }
}
