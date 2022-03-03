using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketImage : MonoBehaviour
{
    [SerializeField] Texture2D[] digits;
    [SerializeField] Texture2D[] toppings;
    [SerializeField] Texture2D[] cakes;

    public Texture2D getCake(int cakeID)
    {
        return cakes[cakeID];
    }

    public Texture2D getTopping(int toppingID)
    {
        return toppings[toppingID];
    }

    public Texture2D getDigit(int digit)
    {
        return digits[digit];
    }

}
