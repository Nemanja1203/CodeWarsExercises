//My friend John and I are members of the "Fat to Fit Club (FFC)".
//John is worried because each month a list with the weights of members is published
//and each month he is the last on the list which means he is the heaviest.

//I am the one who establishes the list so I told him: "Don't worry any more,
//I will modify the order of the list".It was decided to attribute a "weight" to numbers.
//The weight of a number will be from now on the sum of its digits.

//For example 99 will have "weight" 18, 100 will have "weight" 1 so in the list 100 will come before 99.

//Given a string with the weights of FFC members in normal order can you give this string
//ordered by "weights" of these numbers?

//Example:
//"56 65 74 100 99 68 86 180 90" ordered by numbers weights becomes: 

//"100 180 90 56 65 74 68 86 99"
//When two numbers have the same "weight", let us class them as if they were strings(alphabetical ordering)
//and not numbers:

//180 is before 90 since, having the same "weight" (9), it comes before as a string.

//All numbers in the list are positive numbers and the list can be empty.

//Notes
//it may happen that the input string have leading,
//trailing whitespaces and more than a unique whitespace between two consecutive numbers
//For C: The result is freed.

using System.Text;

namespace KataPersistence;

public class Kata_016_WeightForWeight
{
    public static string orderWeight(string strng)
    {
        if (string.IsNullOrEmpty(strng))
        {
            return string.Empty;
        }

        var normalizedStrng = NormalizeString(strng);
        var weights = normalizedStrng.Split(' ').ToList();

        weights.Sort(new MyStringComparer());
        return string.Join(" ", weights);
    }

    private static string NormalizeString(string strng)
    {
        var str = strng.Trim();
        str = str.ReduceWhitespace();
        return str;
    }
}

public class MyStringComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        var xWeight = x.Select(x => int.Parse(x.ToString())).Sum();
        var yWeight = y.Select(x => int.Parse(x.ToString())).Sum();

        if (xWeight < yWeight)
        {
            return -1;
        }
        else if (yWeight < xWeight)
        {
            return 1;
        }
        else
        {
            return string.Compare(x, y);
        }
    }
}

public static class StringExtension
{
    public static string ReduceWhitespace(this string value)
    {
        var newString = new StringBuilder();
        bool previousIsWhitespace = false;
        for (int i = 0; i < value.Length; i++)
        {
            if (char.IsWhiteSpace(value[i]))
            {
                if (previousIsWhitespace)
                {
                    continue;
                }

                previousIsWhitespace = true;
            }
            else
            {
                previousIsWhitespace = false;
            }

            newString.Append(value[i]);
        }

        return newString.ToString();
    }
}
