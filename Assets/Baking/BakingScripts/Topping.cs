using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topping : MonoBehaviour
{
    [SerializeField] private int toppingName;

    private bool beingHeld = false;

    public int getName()
    {
        return toppingName;
    }

    public Topping(int name)
    {
        toppingName = name;
    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        Cake cake = collision.transform.GetComponent<Cake>();

//        if (!beingHeld && cake)
//        {
//            cake.addTopping(this);
//            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
//            joint.connectedBody = collision.rigidbody;
//        }
//    }

//    public void OnGrab()
//    {
//        beingHeld = true;
//    }

//    public void OnRelease()
//    {
//        beingHeld = false;
//    }
}
