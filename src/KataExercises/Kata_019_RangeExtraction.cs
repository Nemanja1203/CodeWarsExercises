namespace KataExercises;

public class Kata_019_RangeExtraction
{
    public static string Extract(int[] args)
    {
        List<int> range = new List<int>();
        List<string> result = new List<string>();
        range.Add(args[0]);

        for (int i = 1; i < args.Length; i++)
        {
            var el = args[i];

            if (range.Count == 0)
            {
                range.Add(el);
            }
            else if (el == range.Last() + 1)
            {
                range.Add(el);
            }
            else
            {
                if (range.Count > 2)
                {
                    result.Add("" + range.First() + "-" + range.Last());
                }
                else
                {
                    result.Add(string.Join(",", range.Select(x => x.ToString())));
                }
                range.Clear();
                range.Add(el);
            }
        }

        if (range.Count > 2)
        {
            result.Add("" + range.First() + "-" + range.Last());
        }
        else
        {
            result.Add(string.Join(",", range.Select(x => x.ToString())));
        }

        var res = string.Join(",", result);
        return res;
    }
}
