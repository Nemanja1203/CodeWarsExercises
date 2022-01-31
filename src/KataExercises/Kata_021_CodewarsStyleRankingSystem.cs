namespace KataExercises;

public class User
{
    private readonly int _minRank = -8;
    private readonly int _maxRank = 8;
    private readonly int _progressThreshold = 100;

    public User()
    {
        rank = _minRank;
        progress = 0;
    }

    public int rank { get; private set; }
    public int progress { get; private set; }

    public void incProgress(int r)
    {
        if (r == 0 || r < -8 || r > 8)
        {
            throw new ArgumentException();
        }

        int differenceBetweenRanks = GetDifferenceBetweenRanks(r);

        if (differenceBetweenRanks == 0)
        {
            IncreaseRankIfNeeded(3);
        }
        else if (differenceBetweenRanks == -1)
        {
            IncreaseRankIfNeeded(1);
        }
        else if (differenceBetweenRanks < -1)
        {
            // Ignore
        }
        else
        {
            var p = 10 * differenceBetweenRanks * differenceBetweenRanks;
            IncreaseRankIfNeeded(p);
        }
    }

    private int GetDifferenceBetweenRanks(int r)
    {
        if (r == rank)
        {
            return 0;
        }

        if ((r < 0 && rank < 0) || (r > 0 && rank > 0))
        {
            return r - rank;
        }
        else if (rank > 0 && r < 0)
        {
            return r - rank + 1;
        }
        else // if(rank < 0 && r > 0)
        {
            return r - rank - 1;
        }
    }

    private void IncreaseRankIfNeeded(int p)
    {
        if (rank == 8)
        {
            return;
        }

        progress += p;
        
        while (progress >= _progressThreshold)
        {
            if (rank == -1)
            {
                rank = 1;
            }
            else if (rank == _maxRank)
            {
                // Can't progress further
            }
            else
            {
                rank += 1;
            }

            progress -= 100;
        }

        if (rank == 8)
        {
            progress = 0;
        }
    }
}