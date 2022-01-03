using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace KataExercises.UnitTests;

public class Kata_006_PickPeaks_Tests
{
    private static string[] _msg =
    {
        "should support finding peaks",
        "should support finding peaks, but should ignore peaks on the edge of the array",
        "should support finding peaks; if the peak is a plateau, it should only return the position of the first element of the plateau",
        "should support finding peaks; if the peak is a plateau, it should only return the position of the first element of the plateau",
        "should support finding peaks, but should ignore peaks on the edge of the array"
    };

    private static int[][] _array =
    {
        new int[]{1,2,3,6,4,1,2,3,2,1},
        new int[]{3,2,3,6,4,1,2,3,2,1,2,3},
        new int[]{3,2,3,6,4,1,2,3,2,1,2,2,2,1},
        new int[]{2,1,3,1,2,2,2,2,1},
        new int[]{2,1,3,1,2,2,2,2}
    };

    private static int[][] _posS =
    {
        new int[]{3,7},
        new int[]{3,7},
        new int[]{3,7,10},
        new int[]{2,4},
        new int[]{2}
    };

    private static int[][] peaksS =
    {
        new int[]{6,3},
        new int[]{6,3},
        new int[]{6,3,2},
        new int[]{3,2},
        new int[]{3}
    };

    [Test]
    public void SampleTests()
    {
        for (int n = 0; n < _msg.Length; n++)
        {
            int[] p1 = _posS[n], p2 = peaksS[n];
            var expected = new Dictionary<string, List<int>>()
            {
                ["pos"] = p1.ToList(),
                ["peaks"] = p2.ToList()
            };
            var actual = Kata_012_PickPeaks.GetPeaks(_array[n]);
            Assert.AreEqual(expected, actual, _msg[n]);
        }
    }

    [Test]
    public void GeatPeaks_NoPeaks_DoesntFindAnyPeaks()
    {
        // Arrange
        var arr = new int[] { 1, 2, 3, 4, 5 };

        // Act
        var res = Kata_012_PickPeaks.GetPeaks(arr);

        // Assert
        //res["pos"].Count
        Assert.AreEqual(0, res["pos"].Count);
        Assert.AreEqual(0, res["peaks"].Count);
    }

    [Test]
    public void GetPeaks_OnePeak_FindsOnePeak()
    {
        // Arrange
        var arr = new int[] { 1, 2, 1 };

        // Act
        var res = Kata_012_PickPeaks.GetPeaks(arr);

        // Assert
        Assert.AreEqual(1, res["pos"].Count);
        Assert.AreEqual(1, res["pos"].First());

        Assert.AreEqual(1, res["peaks"].Count);
        Assert.AreEqual(2, res["peaks"].First());
    }

    [Test]
    public void GetPeaks_PeakAtPlateau_FindsOnePeak()
    {
        // Arrange
        var arr = new int[] { 1, 2, 2, 1 };

        // Act
        var res = Kata_012_PickPeaks.GetPeaks(arr);

        // Assert
        Assert.AreEqual(1, res["pos"].Count);
        Assert.AreEqual(1, res["pos"].First());

        Assert.AreEqual(1, res["peaks"].Count);
        Assert.AreEqual(2, res["peaks"].First());
    }

    [Test]
    public void GetPeaks_PeakAtPlateau3_FindsOnePeak()
    {
        // Arrange
        var arr = new int[] { 1, 2, 3, 3, 3, 2, 1 };

        // Act
        var res = Kata_012_PickPeaks.GetPeaks(arr);

        // Assert
        Assert.AreEqual(1, res["pos"].Count);
        Assert.AreEqual(2, res["pos"].First());

        Assert.AreEqual(1, res["peaks"].Count);
        Assert.AreEqual(3, res["peaks"].First());
    }

    [Test]
    public void GetPeaks_PlateauNoPieak_DoesntFindAnyPeaks()
    {
        // Arrange
        var arr = new int[] { 1, 2, 2, 3 };

        // Act
        var res = Kata_012_PickPeaks.GetPeaks(arr);

        // Assert
        Assert.AreEqual(0, res["pos"].Count);
        Assert.AreEqual(0, res["peaks"].Count);
    }
}
