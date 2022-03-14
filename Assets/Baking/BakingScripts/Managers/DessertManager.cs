using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DessertManager : MonoBehaviour
{
    [SerializeField] GameObject[] desserts;

    public GameObject GetCakeCombination(int ingredient1, int ingredient2)
    { 
        if (ingredient1 == ingredient2)
        {
            switch(ingredient1)
            {
                case (int)ID.DessertID.BaseSlice:
                    return desserts[(int)ID.DessertID.BaseCupcake];
                case (int)ID.DessertID.LemonSlice:
                    return desserts[(int)ID.DessertID.LemonCupcake];
                case (int)ID.DessertID.OrangeSlice:
                    return desserts[(int)ID.DessertID.OrangeCupcake];
                case (int)ID.DessertID.MatchaSlice:
                    return desserts[(int)ID.DessertID.MatchaCupcake];
                case (int)ID.DessertID.ChocolateSlice:
                    return desserts[(int)ID.DessertID.ChocolateCupcake];
                case (int)ID.DessertID.RedVelvetSlice:
                    return desserts[(int)ID.DessertID.RedVelvetCupcake];
                case (int)ID.DessertID.RainbowSlice:
                    return desserts[(int)ID.DessertID.RainbowCupcake];
                case (int)ID.DessertID.BaseCheesecakeSlice:
                    return desserts[(int)ID.DessertID.BaseCheesecakeMini];
                case (int)ID.DessertID.LemonCheesecakeSlice:
                    return desserts[(int)ID.DessertID.LemonCheesecakeMini];
                case (int)ID.DessertID.OrangeCheesecakeSlice:
                    return desserts[(int)ID.DessertID.OrangeCheesecakeMini];
                case (int)ID.DessertID.MatchaCheesecakeSlice:
                    return desserts[(int)ID.DessertID.MatchaCheesecakeMini];
                case (int)ID.DessertID.ChocolateCheesecakeSlice:
                    return desserts[(int)ID.DessertID.ChocolateCheesecakeMini];
                case (int)ID.DessertID.RedVelvetCheesecakeSlice:
                    return desserts[(int)ID.DessertID.RedVelvetCheesecakeMini];
                case (int)ID.DessertID.RainbowCheesecakeSlice:
                    return desserts[(int)ID.DessertID.RainbowCheesecakeMini];
                default:
                    return null;
            }
        } else
        {
            if (ingredient1 > ingredient2)
            {
                int temp = ingredient1;
                ingredient1 = ingredient2;
                ingredient2 = temp;

                switch(ingredient1)
                {
                    case (int)ID.DessertID.BaseCake:
                        if (ingredient2 == (int)ID.DessertID.Cheese)
                        {
                            return desserts[(int)ID.DessertID.BaseCheesecake];
                        } else if (ingredient2 == (int)ID.DessertID.Lemon)
                        {
                            return desserts[(int)ID.DessertID.LemonCake];
                        } else if (ingredient2 == (int)ID.DessertID.Orange)
                        {
                            return desserts[(int)ID.DessertID.OrangeCake];
                        } else if (ingredient2 == (int)ID.DessertID.Matcha)
                        {
                            return desserts[(int)ID.DessertID.MatchaCake];
                        } else if (ingredient2 == (int)ID.DessertID.Chocolate)
                        {
                            return desserts[(int)ID.DessertID.ChocolateCake];
                        } else if (ingredient2 == (int)ID.DessertID.Cherry)
                        {
                            return desserts[(int)ID.DessertID.RedVelvetCake];
                        }
                        return null;
                    case (int)ID.DessertID.LemonCake:
                        if (ingredient2 == (int)ID.DessertID.Cheese)
                        {
                            return desserts[(int)ID.DessertID.LemonCheesecake];
                        }
                        return null;
                    case (int)ID.DessertID.OrangeCake:
                        if (ingredient2 == (int)ID.DessertID.Cheese)
                        {
                            return desserts[(int)ID.DessertID.OrangeCheesecake];
                        }
                        return null;
                    case (int)ID.DessertID.MatchaCake:
                        if (ingredient2 == (int)ID.DessertID.Cheese)
                        {
                            return desserts[(int)ID.DessertID.MatchaCheesecake];
                        }
                        return null;
                    case (int)ID.DessertID.ChocolateCake:
                        if (ingredient2 == (int)ID.DessertID.Cheese)
                        {
                            return desserts[(int)ID.DessertID.ChocolateCheesecake];
                        }
                        return null;
                    case (int)ID.DessertID.RedVelvetCake:
                        if (ingredient2 == (int)ID.DessertID.Cheese)
                        {
                            return desserts[(int)ID.DessertID.RedVelvetCheesecake];
                        }
                        return null;
                    case (int)ID.DessertID.RainbowCake:
                        if ((ingredient2) == (int)ID.DessertID.Cheese)
                        {
                            return desserts[(int)ID.DessertID.RainbowCheesecake];
                        }
                        return null;


                }
            }
        }
        return null;
    }
}