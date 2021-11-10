using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pastry : MonoBehaviour
{
    public List<Texture> decorations;
    private new Renderer renderer;


    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    /*
     * Adds a texture to the gameobject this script is attached to and the list
     * of decorations.
     */
    public void AddDecoration(Texture decoration)
    {
        renderer.material.mainTexture = decoration;

        decorations.Add(decoration);
    }
}
