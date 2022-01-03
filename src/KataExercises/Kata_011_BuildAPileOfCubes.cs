//Your task is to construct a building which will be a pile of n cubes.
//The cube at the bottom will have a volume of n^3, the cube above will have volume of (n-1)^3
//and so on until the top which will have a volume of 1^3.

//You are given the total volume m of the building. Being given m can you find the number n of cubes you will have to build?

//The parameter of the function findNb (find_nb, find-nb, findNb, ...) will be an integer m and you have to return the integer n such as n^3 + (n-1)^3 + ... +1 ^ 3 = m if such a n exists or -1 if there is no such n.

//Examples:
//findNb(1071225)-- > 45

//findNb(91716553919377)-- > -1

namespace KataExercises;

public class Kata_011_BuildAPileOfCubes
{
    // This is slow
    public static long FindNb(long m)
    {
        long currentVolume = 1;

        if (m == 1)
        {
            return currentVolume;
        }
        long i = 2;
        for (; currentVolume < m; i++)
        {
            // Casting is expensive as it is in for loop and we do it every time
            currentVolume += (int)Math.Pow(i, 3);
        }
        return currentVolume == m ? i : -1;
    }

    // TODO: (nm) Add benchmark tests;
    public static long FindNb3(long m)
    {
        long total = 1;
        long i = 2;
        for (; total < m; i++) total += i * i * i;
        return total == m ? i - 1 : -1;
    }

    // https://mathschallenge.net/library/number/sum_of_cubes
    // The sum of the first n cubes is the square of the sum of the first n natural numbers
    public static long FindNb2(long m)
    {
        decimal mSqrt = Sqrt(m);
        if (mSqrt % 1 != 0)
        {
            return -1;
        }

        decimal temp = Sqrt(1 + 8 * mSqrt);
        decimal r1 = (-1 + temp) / 2;

        return r1 % 1 != 0
            ? -1
            : (long)r1;
    }

    // TODO: Save this somewhere
    //https://stackoverflow.com/questions/4124189/performing-math-operations-on-decimal-datatype-in-c
    // x - a number, from which we need to calculate the square root
    // epsilon - an accuracy of calculation of the root from our number.
    // The result of the calculations will differ from an actual value
    // of the root on less than epslion.
    public static decimal Sqrt(decimal x, decimal epsilon = 0.0M)
    {
        if (x < 0)
        {
            throw new OverflowException("Cannot calculate square root from a negative number");
        }

        decimal current = (decimal)Math.Sqrt((double)x);
        decimal previous;
        do
        {
            previous = current;
            if (previous == 0.0M)
            {
                return 0;
            }
            current = (previous + x / previous) / 2;
        }
        while (Math.Abs(previous - current) > epsilon);
        return current;
    }
}
