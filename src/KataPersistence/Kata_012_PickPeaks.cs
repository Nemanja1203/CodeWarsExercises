//In this kata, you will write a function that returns the positions and the values of the "peaks" (or local maxima) of a numeric array.

//For example, the array arr = [0, 1, 2, 5, 1, 0]
//has a peak at position 3 with a value of 5 (since arr [3] equals 5).

//The output will be returned as a Dictionary<string, List<int>> with two key-value pairs: "pos" and "peaks".
//If there is no peak in the given array, simply return { "pos" => new List<int>(), "peaks" => new List<int>()}.

//Example: pickPeaks([3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 3]) should return { pos: [3, 7], peaks: [6, 3]} (or equivalent in other languages)

//All input arrays will be valid integer arrays (although it could still be empty), so you won't need to validate the input.

//The first and last elements of the array will not be considered as peaks (in the context of a mathematical function,
//we don't know what is after and before and therefore, we don't know if it is a peak or not).

//Also, beware of plateaus !!! [1, 2, 2, 2, 1]
//has a peak while [1, 2, 2, 2, 3]
//and [1, 2, 2, 2, 2] do not. In case of a plateau-peak, please only return the position and value of the beginning of the plateau.
//For example: pickPeaks([1, 2, 2, 2, 1]) returns { pos: [1], peaks: [2]} (or equivalent in other languages)

//Have fun!

namespace KataPersistence;

public class Kata_012_PickPeaks
{
    public static Dictionary<string, List<int>> GetPeaks(int[] arr)
    {
        var res = new Dictionary<string, List<int>>
        {
            { "pos", new List<int>() },
            { "peaks", new List<int>() }
        };

        if (arr == null)
        {
            return res;
        }

        int[] lastThree = new int[3];
        int nextIndexForAdd = 0;
        int plateauStartIndex = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            // Add to window
            if (nextIndexForAdd == 0)
            {
                lastThree[nextIndexForAdd] = arr[i];
                nextIndexForAdd++;
            }
            else
            {
                if (lastThree[nextIndexForAdd - 1] != arr[i])
                {
                    lastThree[nextIndexForAdd] = arr[i];
                    nextIndexForAdd++;
                }
                else
                {
                    if (plateauStartIndex != -1)
                    {
                        // Leave it as it is
                    }
                    else
                    {
                        plateauStartIndex = i - 1;
                    }
                }
            }

            // Check window for local maximum
            if (nextIndexForAdd == 3)
            {
                if (lastThree[0] < lastThree[1] && lastThree[1] > lastThree[2])
                {
                    res["pos"].Add(plateauStartIndex == -1 ? i - 1 : plateauStartIndex);
                    res["peaks"].Add(lastThree[1]);
                }

                nextIndexForAdd--;
                lastThree[0] = lastThree[1];
                lastThree[1] = lastThree[2];
                
                plateauStartIndex = -1;
            }
        }

        return res;
    }

    // Best solution 
    public static Dictionary<string, List<int>> GetPeaks2(int[] arr)
    {
        var res = new Dictionary<string, List<int>>
        {
            { "pos", new List<int>() },
            { "peaks", new List<int>() }
        };

        int pos = 0;
        int peaks = 0;

        for (int i = 1; i < arr.Length -1; i++)
        {
            if (arr[i] > arr[i-1])
            {
                pos = i;
                peaks = arr[i];
            }

            if (arr[i] > arr[i+1] && pos != 0)
            {
                res["pos"].Add(pos);
                res["peaks"].Add(peaks);

                pos = 0;
                peaks = 0;
            }
        }

        return res;
    }
}
