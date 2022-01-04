using NUnit.Framework;

namespace KataExercises.UnitTests;

[TestFixture]
public class Kata_014_NumberOfTrailingZerosOfNFactoriel_Tests
{
    [Test]
    public void BasicTests()
    {
        Assert.AreEqual(1, Kata_014_NumberOfTrailingZerosOfNFactoriel.TrailingZeros(5));
        Assert.AreEqual(6, Kata_014_NumberOfTrailingZerosOfNFactoriel.TrailingZeros(25));
        Assert.AreEqual(131, Kata_014_NumberOfTrailingZerosOfNFactoriel.TrailingZeros(531));
    }
}
