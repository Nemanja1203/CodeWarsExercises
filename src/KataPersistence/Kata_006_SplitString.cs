//Complete the solution so that it splits the string into pairs of two characters. If the string contains an odd number of characters then it should replace the missing second character of the final pair with an underscore ('_').

//Examples:

//SplitString.Solution("abc"); // should return ["ab", "c_"]
//SplitString.Solution("abcdef"); // should return ["ab", "cd", "ef"]

namespace KataCodeWars;

public class Kata_006_SplitString
{
    public static string[] Solution(string str)
    {
        if (str.Length % 2 != 0)
        {
            str += "_";
        }

        var strArr = new List<string>();

        for (int i = 0; i < str.Length; i += 2)
        {
            strArr.Add("" + str[i] + str[i + 1]);
        }

        return strArr.ToArray();
    }
}
