//Alright, detective, one of our colleagues successfully observed our target person, Robby the robber.
//We followed him to a secret warehouse, where we assume to find all the stolen stuff.
//The door to this warehouse is secured by an electronic combination lock.
//Unfortunately our spy isn't sure about the PIN he saw, when Robby entered it.

//The keypad has the following layout:

//┌───┬───┬───┐
//│ 1 │ 2 │ 3 │
//├───┼───┼───┤
//│ 4 │ 5 │ 6 │
//├───┼───┼───┤
//│ 7 │ 8 │ 9 │
//└───┼───┼───┘
//    │ 0 │
//    └───┘
//He noted the PIN 1357, but he also said, it is possible that each of the digits he saw
//could actually be another adjacent digit (horizontally or vertically, but not diagonally).
//E.g.instead of the 1 it could also be the 2 or 4. And instead of the 5 it could also be the 2, 4, 6 or 8.

//He also mentioned, he knows this kind of locks. You can enter an unlimited amount of wrong PINs,
//they never finally lock the system or sound the alarm.
//That's why we can try out all possible (*) variations.

//* possible in sense of: the observed PIN itself and all variations considering the adjacent digits

//Can you help us to find all those variations? It would be nice to have a function,
//that returns an array (or a list in Java/Kotlin and C#) of all variations for an observed PIN
//with a length of 1 to 8 digits. We could name the function getPINs (get_pins in python, GetPINs in C#).
//
//But please note that all PINs, the observed one and also the results, must be strings,
//because of potentially leading '0's. We already prepared some test cases for you.

//Detective, we are counting on you!

//For C# user: Do not use Mono. Mono is too slower when run your code.

// Combinations - redosled nije bitan, podskup elemenata
// Variations - redosled je bitan, podskup elemenata
// Permutations - redosled je bitan, svi elementi

// What I'm looking for is called Cartesian product
//https://stackoverflow.com/questions/2419370/how-can-i-compute-a-cartesian-product-iteratively
namespace KataExercises;

public class Kata_017_TheObservedPin
{
    private static readonly Dictionary<string, List<string>> _keypadToVariation = new Dictionary<string, List<string>>
    {
        { "0", new List<string> { "0", "8" } },
        { "1", new List<string> { "1", "2", "4" } },
        { "2", new List<string> { "2", "1", "3", "5" } },
        { "3", new List<string> { "3", "2", "6" } },
        { "4", new List<string> { "4", "1", "5", "7" } },
        { "5", new List<string> { "5", "2", "4", "6", "8" } },
        { "6", new List<string> { "6", "3", "5", "9" } },
        { "7", new List<string> { "7", "4", "8" } },
        { "8", new List<string> { "8", "5", "7", "9", "0" } },
        { "9", new List<string> { "9", "6", "8" } }
    };

    public static List<string> GetPINs(string observedPin)
    {
        var variations = new List<string>();

        // Calculating number of combinations
        //var numberOfCombinations = 1;

        //foreach (var digit in observedPin)
        //{
        //    numberOfCombinations *= _keypadToVariation[digit.ToString()].Count;
        //}

        // Contains mappings only for digits that are used in observed pin
        var pinDigitToVariations = new List<List<string>>();
        foreach (var digit in observedPin)
        {
            pinDigitToVariations.Add(_keypadToVariation[digit.ToString()]);
        }

        var indexes = new int[observedPin.Length];

        while (true)
        {
            variations.Add(GetCombinationForIndexes(indexes, pinDigitToVariations));

            int j = indexes.Length - 1;

            while (true)
            {
                indexes[j] += 1;
                if (indexes[j] < pinDigitToVariations[j].Count)
                {
                    break;
                }
                indexes[j] = 0;
                j -= 1;
                if (j < 0) break;
            }

            if (j < 0) break;
        }

        //Console.WriteLine($"Number of combinations for observed PIN: {observedPin} is {numberOfCombinations}");

        return variations;
    }

    private static string GetCombinationForIndexes(int[] indexes, List<List<string>> pinDigitToVariations)
    {
        var res = string.Empty;

        for (int i = 0; i < indexes.Length; i++)
        {
            res += pinDigitToVariations[i][indexes[i]];
        }

        return res;
    }
}
