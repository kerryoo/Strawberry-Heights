using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pastry : MonoBehaviour
{
    [SerializeField] Decoration obj;

    public List<string> decorations = new List<string>();

    private void Start()
    {
        gameObject.tag = "Pastry";
        AddDecoration(obj);
    }

    /*
     * Just here for testing.
     */
    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            
        }
    }

    /*
     * Adds a texture to the gameobject this script is attached to and the list
     * of decorations.
     */
    public void AddDecoration(Decoration decoration)
    {
        decoration.attachToPastry(this.gameObject);
        decorations.Add(decoration.tag);
    }
}
