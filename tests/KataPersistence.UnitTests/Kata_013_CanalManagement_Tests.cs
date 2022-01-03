using NUnit.Framework;

namespace KataExercises.UnitTests;

[TestFixture]
public class Kata_013_CanalManagement_Tests
{

    [TestCase(new uint[] { 2, 3, 6, 1 }, new uint[] { 1, 2 }, 7, 38)]
    [TestCase(new uint[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, new uint[] { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, 30, 868)]
    public void SampleTests(uint[] lowQueue, uint[] highQueue, int lockLength, int expected)
      => Tester.Act(lowQueue, highQueue, (uint)lockLength, (uint)expected);

    [TestCase(new uint[] { 4, 1, 8, 2, 6 }, new uint[0], 8, 54)]
    public void NoHighQueueTest(uint[] lowQueue, uint[] highQueue, int lockLength, int expected)
      => Tester.Act(lowQueue, highQueue, (uint)lockLength, (uint)expected);

    [TestCase(new uint[0], new uint[] { 4, 4, 7, 2, 8, 5 }, 8, 80)]
    public void NoLowQueueTest(uint[] lowQueue, uint[] highQueue, int lockLength, int expected)
      => Tester.Act(lowQueue, highQueue, (uint)lockLength, (uint)expected);

    [TestCase(new uint[0], new uint[0], 10, 0)]
    public void NoQueuesTest(uint[] lowQueue, uint[] highQueue, int lockLength, int expected)
      => Tester.Act(lowQueue, highQueue, (uint)lockLength, (uint)expected);
}

internal static class Tester
{

    public static void Act(uint[] lowQueue, uint[] highQueue, uint lockLength, uint expected)
    {
        var low = $"[{string.Join(",", lowQueue)}]";
        var high = $"[{string.Join(",", highQueue)}]";
        var msg = $"Incorrect answer for\n\t:low = {low}\n\thigh={high}";
        var actual = Kata_013_CanalManagement.CanalMania(lowQueue, highQueue, lockLength);
        Assert.AreEqual(expected, actual, msg);
    }
}
