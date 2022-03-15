using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class TestManager : MonoBehaviour
{
    [SerializeField] Box box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            box.GetComponent<Grabbable>().OnJointBreak.Invoke(null, null);
        }
    }
}
