using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryPlayer : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    /*
     * For now, just rotate the player left and right when a and s are pressed
     * respectively.
     */
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(new Vector3(0f, speed, 0f), Space.Self);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(new Vector3(0f, -speed, 0f), Space.Self);
        }
    }
}
