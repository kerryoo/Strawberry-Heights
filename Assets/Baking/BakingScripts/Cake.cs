using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    [SerializeField] string cakeType;
    private List<Topping> toppings = new List<Topping>();

    public List<Topping> getToppings()
    {
        return toppings;
    }

    /*
     * Attaches decoration to the pastry, and appends the name of the
     * decoration to the list of decorations on the pastry.
     */
    public void addTopping(Topping topping)
    {
        toppings.Add(topping);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Topping topping = collision.gameObject.GetComponent<Topping>();

        if (topping)
        {
            addTopping(topping);
            topping.GetComponent<Rigidbody>().isKinematic = true;
            collision.transform.parent = transform;
        }
    }

}
