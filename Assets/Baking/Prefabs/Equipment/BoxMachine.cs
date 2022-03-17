using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMachine : MonoBehaviour
{
    [SerializeField] GameObject boxObj;
    [SerializeField] Transform spawnLocation;

    public void onButtonPress()
    {
        Instantiate(boxObj, spawnLocation.position, Quaternion.identity);
    }
}
