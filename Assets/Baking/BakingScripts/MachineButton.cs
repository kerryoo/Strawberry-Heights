using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineButton : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Vector3 spawnPoint;

    private void OnMouseDown()
    {
        Instantiate(prefab, spawnPoint, Quaternion.identity);
    }
}
