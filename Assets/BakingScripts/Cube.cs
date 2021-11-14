using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A "decoration" used for testing.
 */
public class Cube : Decoration
{
    private void Start()
    {
        gameObject.tag = "cube";
    }

    override public void attachToPastry(GameObject pastry)
    {
        this.transform.parent = pastry.transform;
    }
}
