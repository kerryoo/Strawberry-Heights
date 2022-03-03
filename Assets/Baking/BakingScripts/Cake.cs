using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    [SerializeField] int cakeType;
    [SerializeField] GameObject pullApartResult;
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

    public void onPullApart()
    {
        Instantiate(pullApartResult, transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
        Instantiate(pullApartResult, transform.position + new Vector3(0.1f, 0, 0), Quaternion.identity);
        Instantiate(pullApartResult, transform.position + new Vector3(0, 0, 0.1f), Quaternion.identity);
        Destroy(gameObject);
    }



}
