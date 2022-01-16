using NUnit.Framework;

namespace KataExercises.UnitTests;

public class Kata_018_ParseIntReloaded_Tests
{
    [Test]
    public void FixedTests()
    {
        Assert.AreEqual(1, Kata_018_ParseIntReloaded.ParseInt("one"));
        Assert.AreEqual(20, Kata_018_ParseIntReloaded.ParseInt("twenty"));
        Assert.AreEqual(246, Kata_018_ParseIntReloaded.ParseInt("two hundred forty-six"));
    }

    [Test]
    public void ParseInt_One_1()
    {
        // Arrange
        var numberAsString = "one";

        // Act
        var res = Kata_018_ParseIntReloaded.ParseInt(numberAsString);

        // Assert
        Assert.AreEqual(1, res);
    }

    [Test]
    public void ParseInt_TwoHundredFortySix_246()
    {
        // Arrange
        var numberAsString = "two hundred forty-six";

        // Act
        var res = Kata_018_ParseIntReloaded.ParseInt(numberAsString);

        // Assert
        Assert.AreEqual(246, res);
    }

    [Test]
    public void ParseInt_TwentyTwoHundred_2200()
    {
        // Arrange
        var numberAsString = "twenty two hundred";

        // Act
        var res = Kata_018_ParseIntReloaded.ParseInt(numberAsString);

        // Assert
        Assert.AreEqual(2200, res);
    }

    [Test]
    public void ParseInt_TwoThousandTwoHundred_2200()
    {
        // Arrange
        var numberAsString = "two thousand two hundred";

        // Act
        var res = Kata_018_ParseIntReloaded.ParseInt(numberAsString);

        // Assert
        Assert.AreEqual(2200, res);
    }

    [Test]
    public void ParseInt__666666()
    {
        // Arrange
        var numberAsString = "six hundred sixty-six thousand six hundred sixty-six";

        // Act
        var res = Kata_018_ParseIntReloaded.ParseInt(numberAsString);

        // Assert
        Assert.AreEqual(666_666, res);
    }

    [Test]
    public void ParseInt__864452()
    {
        // Arrange
        var numberAsString = "eight hundred and sixty-four thousand four hundred and fifty-two";

        // Act
        var res = Kata_018_ParseIntReloaded.ParseInt(numberAsString);

        // Assert
        Assert.AreEqual(864_452, res);
    }
    
    [Test]
    public void ParseInt_OneThousandThreeHundredAndThirtySeven_1337()
    {
        // Arrange
        var numberAsString = "one thousand three hundred and thirty-seven";

        // Act
        var res = Kata_018_ParseIntReloaded.ParseInt(numberAsString);

        // Assert
        Assert.AreEqual(1_337, res);
    }
    
    [Test]
    public void ParseInt_SevenHundredThousand_700000()
    {
        // Arrange
        var numberAsString = "seven hundred thousand";

        // Act
        var res = Kata_018_ParseIntReloaded.ParseInt(numberAsString);

        // Assert
        Assert.AreEqual(700_000, res);
    }


}
