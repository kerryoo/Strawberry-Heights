using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    public string cakeType;
    public Dictionary<Topping, int> toppingsToCount = new Dictionary<Topping, int>();
}
