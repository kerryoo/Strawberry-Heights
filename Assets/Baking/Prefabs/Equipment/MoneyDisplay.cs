using System;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] Text earningsAmount;
    [SerializeField] AudioSource makeMoneySound;

    public void updateCashDisplay(float cash)
    {
        earningsAmount.text = "$" + Math.Round(cash, 2);
        makeMoneySound.Play();
    }
}
