using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pastry : MonoBehaviour
{
    private List<string> decorations = new List<string>();

    private void Start()
    {
        gameObject.tag = "Pastry";
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }

    public List<string> getDecorations()
    {
        return decorations;
    }

    /*
     * Attaches decoration to the pastry, and appends the name of the
     * decoration to the list of decorations on the pastry.
     */
    public void addDecoration(Decoration decor)
    {
        decor.attachToPastry(gameObject);
        decorations.Add(decor.tag);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Decoration decor = collision.gameObject.GetComponent<Decoration>();
        if (decor)
        {
            addDecoration(decor);
            Destroy(decor.GetComponent<Rigidbody>());
        }
    }

}
