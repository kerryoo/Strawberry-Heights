using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketImage : MonoBehaviour
{
    [SerializeField] Texture2D[] digits;
    [SerializeField] int[] cakeIds;
    [SerializeField] Texture2D[] cakes;

    public Texture2D getCake(int cakeId)
    {
        return cakes[getCakeIdIndex(cakeId)];
    }

    public Texture2D getDigit(int digit)
    {
        return digits[digit];
    }

    private int getCakeIdIndex(int cakeId)
    {
        for (int i = 0; i < cakeIds.Length; i++)
        {
            if (cakeId == cakeIds[i])
            {
                return i;
            }
        }

        return -1;
    }

}
