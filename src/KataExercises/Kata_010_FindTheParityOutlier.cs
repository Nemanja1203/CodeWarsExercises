//Move the first letter of each word to the end of it, then add "ay" to the end of the word. Leave punctuation marks untouched.

//Examples
//Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
//Kata.PigIt("Hello world !");     // elloHay orldway !

namespace KataExercises;

public class Kata_010_FindTheParityOutlier
{
    public static int Find(int[] integers)
    {
        int evenNo = 0;
        int oddNo = 0;
        for (int i = 0; i < 3; i++)
        {
            // even
            if (integers[i] % 2 == 0)
            {
                evenNo++;
            }
            else
            {
                oddNo++;
            }
        }

        return evenNo > oddNo
            ? integers.Where(x => x % 2 != 0).First()
            : integers.Where(x => x % 2 == 0).First();
    }
}
