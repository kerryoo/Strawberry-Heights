using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BalanceSheet
{
    public static readonly float timePerLevel = 480f;
    public static readonly float timePerTicket = 100f;
    public static readonly float createCakeCooldown = 0.5f;
    public static readonly float minCollisionMag = 2f;
    public static readonly float cakeFreshnessTime = 120f;

    public static readonly Dictionary<int, float> flavorToValue = new Dictionary<int, float> {
        {(int)ID.FlavorID.Base, 10},
        {(int)ID.FlavorID.Lemon, 20},
        {(int)ID.FlavorID.Matcha, 40},
        {(int)ID.FlavorID.Chocolate, 80},
        {(int)ID.FlavorID.Orange, 160},
        {(int)ID.FlavorID.RedVelvet, 320},
        {(int)ID.FlavorID.ChocolateMatcha, 160},
        {(int)ID.FlavorID.PassionFruit, 320},
        {(int)ID.FlavorID.Raspberry, 480},
        {(int)ID.FlavorID.Rainbow, 10000},
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

    public static readonly Dictionary<int, int[]> levelToPossibleCakes = new Dictionary<int, int[]>
    {
        {1,  new int[]
            {
                (int)ID.DessertID.BaseCake,
                (int)ID.DessertID.BaseSlice,
                (int)ID.DessertID.BaseCupcake,
            }
        }
    };

    public static readonly Dictionary<int, float[]> levelToCustomerSpawnTimeRange = new Dictionary<int, float[]>
    {
        {1,  new float[]
            {
                20f, 40f
            }
        }
    };

    public static readonly float[] freshnessDiminishTimeMultipliers = new float[]
    {
        0.6f,
        0.7f,
        0.8f,
        0.9f,
    };

    public static readonly float[] ticketTimeRatingPercentages = new float[]
    {
        0.6f,
        0.7f,
        0.8f,
        0.9f,
    };

    public static readonly Dictionary<int, float> ratingToMultiplier = new Dictionary<int, float> {
        {1, 0.5f},
        {2, 0.75f},
        {3, 1},
        {4, 1.5f},
        {5, 3f},
    };

    public static float getCakePrice(int cakeID)
    {
        return flavorToValue[cakeID % 100] * typeToMultiplier[cakeID / 100];
    }
}
