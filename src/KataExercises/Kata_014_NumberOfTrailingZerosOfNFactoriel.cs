//Write a program that will calculate the number of trailing zeros in a factorial of a given number.

//N! = 1 * 2 * 3 * ... * N

//Be careful 1000! has 2568 digits...

//For more info, see: http://mathworld.wolfram.com/Factorial.html

//Examples
//zeros(6) = 1
//# 6! = 1 * 2 * 3 * 4 * 5 * 6 = 720 --> 1 trailing zero

//zeros(12) = 2
//# 12! = 479001600 --> 2 trailing zeros
//Hint: You're not meant to calculate the factorial. Find another way to find the number of zeros.

namespace KataExercises;

public class Kata_014_NumberOfTrailingZerosOfNFactoriel
{
    public static int TrailingZeros(int n)
    {
        //https://mathworld.wolfram.com/Factorial.html
        int kMin = 1;
        int kMax = (int)Math.Floor(Math.Log(n, 5));

        int z = 0;

        for (int k = kMin; k <= kMax; k++)
        {
            z += (int)Math.Floor(n / (Math.Pow(5, k)));
        }

        return z;
    }
}
