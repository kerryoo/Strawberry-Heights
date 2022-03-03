using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTouch : MonoBehaviour
{
    private GameObject cakeToSpawn;
    private Transform spawnLocation;
    private float cooldown;
    private float lastCreatedCake = 0f;

    public void setLeverTouch(GameObject cakeToSpawn, Transform spawnLocation, float cooldown)
    {
        this.cakeToSpawn = cakeToSpawn;
        this.spawnLocation = spawnLocation;
        this.cooldown = cooldown;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "LeverHandle" && Time.time > lastCreatedCake + cooldown)
        {
            Instantiate(cakeToSpawn, spawnLocation.position, Quaternion.identity);
            lastCreatedCake = Time.time;
        }
    }
}