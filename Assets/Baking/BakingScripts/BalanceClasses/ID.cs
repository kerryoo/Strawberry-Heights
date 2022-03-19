using System;
public class ID
{
    public enum DessertID
    {
        BaseCake = 1000,
        LemonCake = 1001,
        OrangeCake = 1002,
        MatchaCake = 1003,
        ChocolateCake = 1004,
        RedVelvetCake = 1005,
        RainbowCake = 1006,

        RaspberryCake = 1007,
        OreoCake = 1008,
        PassionFruitCake = 1009,
        ChocolateMatchaCake = 1010,
        
        BigRainbowCake = 1011,
        HugeRainbowCake = 1012,

        BaseSlice = 1100,
        LemonSlice = 1101,
        OrangeSlice = 1102,
        MatchaSlice = 1103,
        ChocolateSlice = 1104,
        RedVelvetSlice = 1105,
        RainbowSlice = 1106,

        RaspberrySlice = 1107,
        OreoSlice = 1108,
        PassionFruitSlice = 1109,
        ChocolateMatchaSlice = 1110,

        BaseCupcake = 1200,
        LemonCupcake = 1201,
        OrangeCupcake = 1202,
        MatchaCupcake = 1203,
        ChocolateCupcake = 1204,
        RedVelvetCupcake = 1205,
        RainbowCupcake = 1206,

        BaseCheesecake = 1300,
        LemonCheesecake = 1301,
        OrangeCheesecake = 1302,
        MatchaCheesecake = 1303,
        ChocolateCheesecake = 1304,
        RedVelvetCheesecake = 1305,
        RainbowCheesecake = 1306,

        BaseCheesecakeSlice = 1400,
        LemonCheesecakeSlice = 1401,
        OrangeCheesecakeSlice = 1402,
        MatchaCheesecakeSlice = 1403,
        ChocolateCheesecakeSlice = 1404,
        RedVelvetCheesecakeSlice = 1405,
        RainbowCheesecakeSlice = 1406,

        BaseCheesecakeMini = 1500,
        LemonCheesecakeMini = 1501,
        OrangeCheesecakeMini = 1502,
        MatchaCheesecakeMini = 1503,
        ChocolateCheesecakeMini = 1504,
        RedVelvetCheesecakeMini = 1505,
        RainbowCheesecakeMini = 1506,

        Cheese = 2000,
        Lemon = 2001,
        Orange = 2002,
        Matcha = 2003,
        Chocolate = 2004,
        Cherry = 2005,

        LemonWhole = 2101,
        OrangeWhole = 2102
    }

    public enum CakeShapeID
    {
        Cake = 10,
        Slice = 11,
        Cupcake = 12,
        Cheesecake = 13,
        CheeseSlice = 14,
        CheeseMini = 15
    }

    public enum FlavorID
    {
        Base = 0,
        Lemon = 1,
        Orange = 2,
        Matcha = 3,
        Chocolate = 4,
        RedVelvet = 5,
        Rainbow = 6,
        Raspberry = 7,
        Oreo = 8,
        PassionFruit = 9,
        ChocolateMatcha = 10,
    }

    public enum ReactionID
    {
        Angry = 0,
        Disgusted = 1,
        Satisfied = 2,
        Great = 3,
        Perfect = 4
    }
}
