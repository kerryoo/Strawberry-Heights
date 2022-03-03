using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] GameObject[] leverTriggers;
    [SerializeField] GameObject[] cakesToSpawn;
    [SerializeField] Transform spawnLocation;

    private void Awake()
    {
        for (int i = 0; i < leverTriggers.Length && i < cakesToSpawn.Length; i++)
        {
            LeverTouch leverTouch = leverTriggers[i].AddComponent<LeverTouch>();
            leverTouch.setLeverTouch(cakesToSpawn[i], spawnLocation, BalanceSheet.createCakeCooldown);
        }
    }
}
