//A perfect power is a classification of positive integers:

//In mathematics, a perfect power is a positive integer that can be expressed
//as an integer power of another positive integer.
//More formally, n is a perfect power if there exist natural numbers m > 1, and k > 1 such that m^k = n.

//Your task is to check wheter a given integer is a perfect power.
//If it is a perfect power, return a pair m and k with mk = n as a proof.
//Otherwise return Nothing, Nil, null, NULL, None or your language's equivalent.

//Note: For a perfect power, there might be several pairs. For example 81 = 3^4 = 9^2,
//so (3, 4) and (9,2) are valid solutions. However, the tests take care of this,
//so if a number is a perfect power, return any pair that proves it.

//Examples
//IsPerfectPower(4) => (2, 2)
//IsPerfectPower(5) => null
//IsPerfectPower(8) => (2, 3)
//IsPerfectPower(9) => (3, 2)

namespace KataExercises;

public class Kata_015_PerfectPower
{
    public static (int, int)? IsPerfectPower(int n)
    {
        if (n < 4)
        {
            return null;
        }

        var divisorsOfN = new List<int>();
        int maxDevisor = (int)Math.Ceiling(Math.Sqrt(n));
        for (int i = 2; i <= maxDevisor; i++)
        {
            if (((double)n / i) % 1 == 0)
            {
                divisorsOfN.Add(i);
            }
        }

        int kMax = (int)Math.Ceiling(Math.Log2(n));
        foreach (var m in divisorsOfN)
        {
            int k = 2;
            int result;
            do
            {
                result = (int)Math.Pow(m, k);
                if (result == n)
                {
                    return new(m, k);
                }
                k++;
            } while (k <= kMax);
        }

        return null;
    }
}
