using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationPad : MonoBehaviour
{
    [SerializeField] Texture decoration;

    /* Check if the collided object has the Pastry script attached to it.
     * Look into methods GetComponent and HasComponent in the Unity Documentation.
     * If the Pastry script is attached to it, call the Pastry's AddDecoration(Texture)
     * method with the decoration pad's texture as a parameter.
     */
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
