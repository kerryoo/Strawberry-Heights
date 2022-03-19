using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BakeryManager : GameManager
{
    private static BakeryManager instance;

    [SerializeField] TicketManager ticketManager;
    [SerializeField] DataManager dataManager;
    [SerializeField] Timer dayTimer;
    [SerializeField] Infoboard infoboard;
    [SerializeField] MoneyDisplay moneyDisplay;

    public DayStartEvent dayStartEvent;

    public string username { get; private set; }
    public float cash { get; private set; }
    public float dailyEarnings { get; private set; }
    public int day { get; private set; }
    public int level { get; private set; }

    private bool dayInAction = false;

    private float minCustomerSpawnTime;
    private float maxCustomerSpawnTime;
    private float nextCustomerSpawnTime;

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

    private void Start()
    {
        username = "global";
        day = 1;
        level = 1;
        Cursor.lockState = CursorLockMode.Locked;
        dayStartEvent.AddListener(infoboard.onNewDay);
        dayStartEvent.AddListener(ticketManager.onNewDay);

        dayTimer.timeUpEvent.AddListener(onDayEnd);

        startDay();

    }

    private void Update()
    {
        if (dayInAction)
        {
            dailyActivitiesUpdate();
        }
    }

    private void startDay()
    {
        dayStartEvent.Invoke(day, level);

        Debug.Log(level);

        minCustomerSpawnTime = BalanceSheet.levelToCustomerSpawnTimeRange[level][0];
        maxCustomerSpawnTime = BalanceSheet.levelToCustomerSpawnTimeRange[level][1];
        nextCustomerSpawnTime = Time.time + UnityEngine.Random.Range(minCustomerSpawnTime, maxCustomerSpawnTime);

        dayTimer.setTimer(BalanceSheet.timePerLevel);

        dayInAction = true;
    }

    private void onDayEnd()
    {
        dayTimer.timeUpEvent.RemoveAllListeners();
        dayInAction = false;
    }

    private void dailyActivitiesUpdate()
    {
        infoboard.updateDayTimerUI();

        if (Time.time > nextCustomerSpawnTime)
        {
            ticketManager.createCustomer();
            nextCustomerSpawnTime = Time.time + UnityEngine.Random.Range(minCustomerSpawnTime, maxCustomerSpawnTime);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            cash += 99.32411231f;
        }
    }

    public int gradeCake(List<Dessert> connectedDesserts, Dictionary<int, int> ticketOrder, float timeLeft, int ticketID)
    {
        int totalNumberOfCakes = 0;

        float totalFreshness = 0;
        float rawEarnings = 0;
        int incorrectness = 0;

        foreach (int cakeId in ticketOrder.Keys)
        {
            int cakeIdCount = ticketOrder[cakeId];
            totalNumberOfCakes += cakeIdCount;

            for (int i = 0; i < ticketOrder[cakeId]; i++)
            {
                for (int j = connectedDesserts.Count - 1; j >= 0 && cakeIdCount > 0; j--)
                {
                    if (connectedDesserts[j].getCakeType() == cakeId)
                    {
                        cakeIdCount--;
                        totalFreshness += connectedDesserts[j].freshness;
                        rawEarnings += BalanceSheet.getCakePrice(cakeId);
                        connectedDesserts.RemoveAt(j);
                    } 
                }

                while (cakeIdCount > 0)
                {
                    incorrectness++;
                    cakeIdCount--;
                }
            }
        }

        incorrectness += connectedDesserts.Count;

        float averageFreshness = totalFreshness / totalNumberOfCakes;
        float timeRating = calculateTimeRating(timeLeft);

        int averageRating = (int) Math.Round(averageFreshness + timeRating) / 2;
        averageRating -= incorrectness;

        if (averageRating < 1)
        {
            averageRating = 1;
        }

        float adjustedEarnings = rawEarnings * BalanceSheet.ratingToMultiplier[averageRating];
        dailyEarnings += adjustedEarnings;

        int freshnessRating = (int)Math.Round(averageFreshness);
        int customerReactionId = 0;

        if (freshnessRating < 3)
        {
            customerReactionId = (int)ID.ReactionID.Disgusted;
        } else if (averageRating < 3)
        {
            customerReactionId = (int)ID.ReactionID.Angry;
        } else if (averageRating == 3)
        {
            customerReactionId = (int)ID.ReactionID.Satisfied;
        } else if (averageRating == 4)
        {
            customerReactionId = (int)ID.ReactionID.Great;
        } else if (averageRating == 5)
        {
            customerReactionId = (int)ID.ReactionID.Perfect;
        }

        ticketManager.onTicketComplete(ticketID, customerReactionId);
        moneyDisplay.updateCashDisplay(dailyEarnings);

        return (int)Math.Round(adjustedEarnings);

    }

    private int calculateTimeRating(float timeLeft)
    {
        float timeUsedPercentage = 1 - (timeLeft / BalanceSheet.timePerTicket);
        if (timeUsedPercentage < BalanceSheet.ticketTimeRatingPercentages[0])
        {
            return 5;
        } else if (timeUsedPercentage < BalanceSheet.ticketTimeRatingPercentages[1])
        {
            return 4;
        } else if (timeUsedPercentage < BalanceSheet.ticketTimeRatingPercentages[2])
        {
            return 3;
        } else if (timeUsedPercentage < BalanceSheet.ticketTimeRatingPercentages[3])
        {
            return 2;
        } else
        {
            return 1;
        }
    }


    public void loadGame(SaveData saveData)
    {
        //TODO load the game
    }

}
