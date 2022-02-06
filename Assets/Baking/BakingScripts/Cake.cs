using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    private List<string> toppings = new List<string>();

    private void Start()
    {
        gameObject.tag = "Pastry";
    }

    // Used for testing
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }

    public List<string> getToppings()
    {
        return toppings;
    }

    /*
     * Attaches decoration to the pastry, and appends the name of the
     * decoration to the list of decorations on the pastry.
     */
    public void addTopping(Topping topping)
    {
        topping.attachToPastry(gameObject);
        toppings.Add(topping.getName());
    }

    public void OnCollisionEnter(Collision collision)
    {
        Topping topping = collision.gameObject.GetComponent<Topping>();
        if (topping)
        {
            addTopping(topping);
            Destroy(topping.GetComponent<Rigidbody>());
        }
    }

}
