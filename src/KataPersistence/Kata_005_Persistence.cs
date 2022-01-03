namespace KataPersistence;

public static class Kata_005_Persistence
{
    public static int Calculate(long n)
    {
        int count = 0;

        while (n > 9)
        {
            n = n.ToString().Select(x => int.Parse(x.ToString())).Aggregate((a, x) => a * x);
            count++;
        }
        return count;
    }
}
