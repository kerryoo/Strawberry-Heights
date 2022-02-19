using System.Collections.Generic;
public class PossibleType
{
    private Dictionary<int, List<string>> possibleCakeTypes;
    public static string LemonCake = "Lemon";
    public static string ChocolateCake = "Chocolate";
    public static string MatchaCake = "Matcha";

    private Dictionary<int, List<string>> possibleToppingTypes;
    public static string LemonTopping = "Lemon";
    public static string StrawberryTopping = "Strawberry";
    public static string BlueberryTopping = "Blueberry";
    public static string BlackberryTopping = "Blackberry";

    public PossibleType()
    {
        //Initialize possibleCakeTypes
        possibleCakeTypes = new Dictionary<int, List<string>>();
        possibleCakeTypes.Add(1, new List<string>() { LemonCake });
        possibleCakeTypes.Add(2, new List<string>() { LemonCake });
        possibleCakeTypes.Add(3, new List<string>() { LemonCake, ChocolateCake });
        possibleCakeTypes.Add(4, new List<string>() { LemonCake, ChocolateCake });
        possibleCakeTypes.Add(5, new List<string>() { LemonCake, ChocolateCake, MatchaCake });
        possibleCakeTypes.Add(6, new List<string>() { LemonCake, ChocolateCake, MatchaCake });

        //Initialize possibleToppingTypes
        possibleToppingTypes = new Dictionary<int, List<string>>();
        possibleToppingTypes.Add(1, new List<string>() { StrawberryTopping });
        possibleToppingTypes.Add(2, new List<string>() { StrawberryTopping, LemonTopping });
        possibleToppingTypes.Add(3, new List<string>() { StrawberryTopping, LemonTopping });
        possibleToppingTypes.Add(4, new List<string>() { StrawberryTopping, LemonTopping, BlueberryTopping });
        possibleToppingTypes.Add(5, new List<string>() { StrawberryTopping, LemonTopping, BlueberryTopping });
        possibleToppingTypes.Add(6, new List<string>() { StrawberryTopping, LemonTopping, BlueberryTopping, BlackberryTopping });
    }

    public List<string> getPossibleCakeTypes(int level)
    {
        if (possibleCakeTypes.ContainsKey(level))
        {
            return possibleCakeTypes[level];
        }
        return new List<string>();
    }

    public List<string> getPossibleToppingTypes(int level)
    {
        if (possibleToppingTypes.ContainsKey(level))
        {
            return possibleToppingTypes[level];
        }
        return new List<string>();
    }
}
