//In this kata we want to convert a string into an integer. The strings simply represent the numbers in words.

//Examples:

//"one" => 1
//"twenty" => 20
//"two hundred forty-six" => 246
//"seven hundred eighty-three thousand nine hundred and nineteen" => 783919
//Additional Notes:

//The minimum number is "zero" (inclusively)
//The maximum number, which must be supported is 1 million (inclusively)
//The "and" in e.g. "one hundred and twenty-four" is optional, in some cases it's present and in others it's not
//All tested numbers are valid, you don't need to validate them

// https://www.c-sharpcorner.com/Blogs/convert-words-to-numbers-in-c-sharp
namespace KataExercises;

public class Kata_018_ParseIntReloaded
{
    private static readonly Dictionary<string, int> _wordToNumberMapping = new Dictionary<string, int>()
    {

        { "zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
        { "ten", 10 },
        { "eleven", 11 },
        { "twelve", 12 },
        { "thirteen", 13 },
        { "fourteen", 14 },
        { "fifteen", 15 },
        { "sixteen", 16 },
        { "seventeen", 17 },
        { "eighteen", 18 },
        { "nineteen", 19 },
        { "twenty", 20 },
        { "thirty", 30 },
        { "forty", 40 },
        { "fifty", 50 },
        { "sixty", 60 },
        { "seventy", 70 },
        { "eighty", 80 },
        { "ninety", 90 },
        { "hundred", 100 },
        { "thousand", 1_000 },
        { "million", 1_000_000 }
    };

    public static int ParseInt(string s)
    {
        s = s.Replace("-", " ");
        s = s.Replace(" and ", " ");
        s = s.Trim();

        var sSplit = s.Split(" ");
        int res = 0;
        int baseNumber = 0;

        foreach (var item in sSplit)
        {
            if (!string.IsNullOrEmpty(item))
            {
                var n = _wordToNumberMapping[item];
                if (n >= 1_000)
                {
                    res += baseNumber * n;
                    baseNumber = 0;
                }
                else if (n >= 100)
                {
                    baseNumber *= n;
                }
                else
                {
                    baseNumber += n;
                }
            }
        }
        res += baseNumber;
        return res;
    }
}
