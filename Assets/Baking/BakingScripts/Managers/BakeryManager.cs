using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BakeryManager : GameManager
{
    // Customer
    [SerializeField] GameObject customerPreFab;
    [SerializeField] Vector3 customerSpawnPoint;

    [SerializeField] UIManager uiManager;
    [SerializeField] TicketManager ticketManager;
    [SerializeField] DataManager dataManager;

    [SerializeField] Timer dayTimer;
    
    private void Start()
    {
        //spawnCustomer();
        Cursor.lockState = CursorLockMode.Locked;
        startDay();

    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P) || OVRInput.GetDown(OVRInput.Button.Two))
        //{
        //    if (uiManager.isModalOn())
        //    {
        //        uiManager.closeModal();
        //        startDay();
        //    } else
        //    {
        //        uiManager.openDayStartModal(dataManager.day);
        //    }
        //}

        if (dataManager.dayInAction)
        {
            dailyActivitiesUpdate();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        // TESTING: saving game data
        if (Input.GetKeyDown(KeyCode.S))
        {
            dataManager.SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            dataManager.cash += 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            dataManager.LoadGame();
        }
    }

    private void startDay()
    {
        dayTimer.timeUpEvent.AddListener(onDayEnd);
        dayTimer.setTimer(BalanceSheet.timePerLevel);
        dataManager.dayInAction = true;
    }

    private void onDayEnd()
    {
        dayTimer.timeUpEvent.RemoveAllListeners();
        uiManager.openDayEndModal(dataManager.day);
        dataManager.dayInAction = false;
    }

    private void dailyActivitiesUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Y) || OVRInput.GetDown(OVRInput.Button.One))
        {
            ticketManager.createCustomer();
        }

    }

}
