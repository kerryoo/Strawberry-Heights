using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BalanceSheet
{
    public static readonly float timePerLevel = 300f;
    public static readonly float timePerTicket = 100f;
    public static readonly float createCakeCooldown = 0.5f;
    public static readonly float minCollisionMag = 2f;

    public static readonly Dictionary<int, float> cakeToValue = new Dictionary<int, float> {
        {(int)ID.DessertID.BaseCake, 10},
        {(int)ID.DessertID.LemonCake, 20},
        {(int)ID.DessertID.MatchaCake, 40},
        {(int)ID.DessertID.ChocolateCake, 80},
        {(int)ID.DessertID.OrangeCake, 160},
        {(int)ID.DessertID.RedVelvetCake, 320},
        {(int)ID.DessertID.ChocolateMatchaCake, 160},
        {(int)ID.DessertID.PassionFruitCake, 320},
        {(int)ID.DessertID.RaspberryCake, 480},
        {(int)ID.DessertID.RainbowCake, 10000},
    };

    public static readonly Dictionary<int, float> typeToMultiplier = new Dictionary<int, float> {
        {(int)ID.CakeShapeID.Cake, 1},
        {(int)ID.CakeShapeID.Slice, 0.3f},
        {(int)ID.CakeShapeID.Cupcake, 0.8f},
        {(int)ID.CakeShapeID.Cheesecake, 1.5f},
        {(int)ID.CakeShapeID.CheeseSlice, 0.4f},
        {(int)ID.CakeShapeID.CheeseMini, 1},
    };

    public static readonly Dictionary<int, float> typeToWeight = new Dictionary<int, float> {
        {(int)ID.CakeShapeID.Cake, 1},
        {(int)ID.CakeShapeID.Slice, 0.25f},
        {(int)ID.CakeShapeID.Cupcake, 0.5f},
        {(int)ID.CakeShapeID.Cheesecake, 1f},
        {(int)ID.CakeShapeID.CheeseSlice, 0.25f},
        {(int)ID.CakeShapeID.CheeseMini, 0.5f},
    };
}
