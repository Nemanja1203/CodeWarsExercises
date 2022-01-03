namespace KataPersistence;

public class Kata_005_PersistenceRecursion
{
    public static int Calculate(long n)
    {
        int result = 1;

        // If already single digit number
        if (n < 10)
        {
            return 0;
        }

        // Get digits
        var nAsString = n.ToString();
        var digits = nAsString.Select(t => Int32.Parse(t + "")).ToList();

        // Multiply digits
        var tempResult = digits.Aggregate((a, x) => a * x);

        // Check number of digits in result
        var noDigits = tempResult.ToString().Length;

        if (noDigits > 1)
        {
            result += Calculate(tempResult);
        }

        return result;
    }
}
