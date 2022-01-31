namespace KataExercises.UnitTests;
using NUnit.Framework;

[TestFixture]
public class Kata_021_CodewarsStyleRankingSystem_Tests
{
    [Test]
    public void MyTest()
    {
        // Arrange
        User user = new User();
        
        // Act
        user.incProgress(1);
        
        // Assert
        Assert.AreEqual(-2, user.rank);
    }
}