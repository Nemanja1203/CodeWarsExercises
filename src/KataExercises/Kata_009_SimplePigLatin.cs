//Move the first letter of each word to the end of it, then add "ay" to the end of the word. Leave punctuation marks untouched.

//Examples
//Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
//Kata.PigIt("Hello world !");     // elloHay orldway !

namespace KataExercises;

public class Kata_009_SimplePigLatin
{
    public static string PigIt(string str)
    {
        Console.WriteLine("Input string: " + str);

        string result = string.Empty;
        //var punctuationMarks = new HashSet<char> { '.', ',', '!', '?' };
        var word = string.Empty;
        foreach (char ch in str)
        {
            if (ch != ' ' && !char.IsPunctuation(ch) && ch != '\n')
            {
                word += ch;
            }
            else
            {
                result += word == string.Empty ? "" : WordFunction(word);
                result += ch;
                word = string.Empty;
            }
        }

        if (word != string.Empty)
        {
            result += WordFunction(word);
        }

        return result;
    }

    private static string WordFunction(string str)
    {
        var result = string.Empty;
        for (int i = 1; i < str.Length; i++)
        {
            result += str[i];
        }
        result += str[0] + "ay";
        return result;
    }
}
