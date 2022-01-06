using System;
using KataPersistence;
using NUnit.Framework;

namespace KataExercises.UnitTests;

[TestFixture]
public class Kata_016_WeightForWeight_Tests
{
    [Test]
    public void Test1()
    {
        Console.WriteLine("****** Basic Tests");
        Assert.AreEqual("2000 103 123 4444 99",
            Kata_016_WeightForWeight.orderWeight("103 123 4444 99 2000"));
        Assert.AreEqual("11 11 2000 10003 22 123 1234000 44444444 9999",
            Kata_016_WeightForWeight.orderWeight("2000 10003 1234000 44444444 9999 11 11 22 123"));
    }

    [Test]
    public void Test2()
    {
        // Arrange
        var inputString = "99 100 101";

        // Act
        var res = Kata_016_WeightForWeight.orderWeight(inputString);

        // Assert
        Assert.AreEqual("100 101 99", res);
    }
}
