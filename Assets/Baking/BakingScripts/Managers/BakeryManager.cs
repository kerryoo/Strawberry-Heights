using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BakeryManager : GameManager
{
    private static BakeryManager instance;

    [SerializeField] UIManager uiManager;
    [SerializeField] TicketManager ticketManager;
    [SerializeField] DessertManager dessertManager;

    [SerializeField] Timer dayTimer;
    public float cash { get; private set; }

    public int day {get; private set; }
    private bool dayInAction = false;


    private void Awake()
    {
        instance = this;
    }

    public static BakeryManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Bakery Manager not initialized!");
                return null;
            }
            return instance;
        }
    }

    public GameObject GetCakeCombination(int ingredient1, int ingredient2)
    {
        return dessertManager.GetCakeCombination(ingredient1, ingredient2);
    }



    private void Start()
    {
        //spawnCustomer();
        day = 1;
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
        //        uiManager.openDayStartModal(day);
        //    }
        //}

        if (dayInAction)
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
    }

    private void startDay()
    {
        dayTimer.timeUpEvent.AddListener(onDayEnd);
        dayTimer.setTimer(BalanceSheet.timePerLevel);
        dayInAction = true;
    }

    private void onDayEnd()
    {
        dayTimer.timeUpEvent.RemoveAllListeners();
        uiManager.openDayEndModal(day);
        dayInAction = false;
    }

    private void dailyActivitiesUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Y) || OVRInput.GetDown(OVRInput.Button.One))
        {
            ticketManager.createCustomer();
        }

    }

}
