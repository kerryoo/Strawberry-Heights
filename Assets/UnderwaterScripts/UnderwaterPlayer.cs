using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterPlayer : MonoBehaviour
{
    [SerializeField] InputController inputController;
    [SerializeField] float interactDistance = 5f;
    

    // Update is called once per frame
    void Update()
    {
        Move();
        if (inputController.Interact)
        {
            Interact();
        }
    }

    private void Move()
    {

    }

    private void Interact()
    {

    }
}
