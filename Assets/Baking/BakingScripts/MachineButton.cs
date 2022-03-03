using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineButton : MonoBehaviour
{
    [SerializeField] GameObject cakePrefab;
    [SerializeField] Transform spawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject newCake = Instantiate(cakePrefab, spawnPoint);
        newCake.transform.localPosition = new Vector3(0, -0.2f, 0);
    }
}
