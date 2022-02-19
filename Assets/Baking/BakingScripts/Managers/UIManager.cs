using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] ModalWindowManager modalWindowManager;
    [SerializeField] ProgressBar progressBar;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI tipsEarnedText;
    [SerializeField] TextMeshProUGUI dayText;
    [SerializeField] BakeryManager gameManager;
    [SerializeField] Timer DayTimer;

    private Dictionary<int, string> dayToDescription;

    private void Start()
    {
        initializeFields();
    }

    private void Update()
    {
        updateDayTimerUI();
        updateTipsEarnedUI();
    }

    private void initializeFields()
    {
        dayToDescription = new Dictionary<int, string>();
        dayToDescription[1] = "Your first day of work! I bet you'll do great!";
    }

    private void updateDayTimerUI()
    {
        timerText.SetText(DayTimer.getTimeLeftString());
        progressBar.currentPercent = 100 * DayTimer.timeLeft / BalanceSheet.timePerLevel;
        progressBar.UpdateUI();
    }

    public void updateDayUI(int dayNumber)
    {
        dayText.SetText("Day " + dayNumber.ToString());
    }

    private void updateTipsEarnedUI()
    {
        tipsEarnedText.SetText(getTipsString());
    }

    private string getTipsString()
    {
        string tipsToDisplay = "0.00";
        if (gameManager.cash < -0.001 || gameManager.cash > 0.001)
        {
            tipsToDisplay = gameManager.cash.ToString("#.##");
        }
        return tipsToDisplay;
    }

    public void openDayStartModal(int dayNumber)
    {
        modalWindowManager.titleText = "Day " + dayNumber;
        modalWindowManager.descriptionText = dayToDescription[dayNumber];
        modalWindowManager.UpdateUI();
        modalWindowManager.OpenWindow();
    }

    public void openDayEndModal(int dayNumber)
    {
        modalWindowManager.titleText = "End of Day " + dayNumber;
        modalWindowManager.descriptionText = "Phew! You made it!" +
            "\nYou even earned $" + getTipsString() + "!";
        modalWindowManager.UpdateUI();
        modalWindowManager.OpenWindow();
    }

    public void closeModal()
    {
        modalWindowManager.CloseWindow();
    }

    public bool isModalOn()
    {
        return modalWindowManager.isOn;
    }
}

