using System.Collections.Generic;
using NUnit.Framework;

namespace KataExercises.UnitTests;

public class Kata_017_TheObservedPin_Tests
{
    [Test]
    public void TestBasic()
    {
        var expectations = new Dictionary<string, string[]>
        {
            {"8", new[] {"5", "7", "8", "9", "0"}},
            {"11", new[] {"11", "22", "44", "12", "21", "14", "41", "24", "42"}},
            {
                "369",
                new[]
                {
                    "339", "366", "399", "658", "636", "258", "268", "669", "668", "266", "369", "398",
                    "256", "296", "259", "368", "638", "396", "238", "356", "659", "639", "666", "359",
                    "336", "299", "338", "696", "269", "358", "656", "698", "699", "298", "236", "239"
                }
            }
        };

        foreach (var pin in expectations)
        {
            CollectionAssert.AreEquivalent(pin.Value, Kata_017_TheObservedPin.GetPINs(pin.Key), "PIN: " + pin);
        }
    }

    [Test]
    public void Test2()
    {
        // Arrange
        var pin = "2";

        // Act
        var res = Kata_017_TheObservedPin.GetPINs(pin);

        // Assert
        Assert.AreEqual(4, res.Count);
        CollectionAssert.AreEquivalent(new[] { "1", "2", "3", "5" }, res);
    }

    [Test]
    public void Test01()
    {
        // Arrange
        var pin = "01";

        // Act
        var res = Kata_017_TheObservedPin.GetPINs(pin);

        // Assert
        Assert.AreEqual(6, res.Count);
        CollectionAssert.AreEquivalent(new[] { "01", "02", "04", "81", "82", "84" }, res);
    }

    [Test]
    public void Test369()
    {
        // Arrange
        var pin = "369";

        // Act
        var res = Kata_017_TheObservedPin.GetPINs(pin);

        // Assert
        Assert.AreEqual(36, res.Count);
    }
}
