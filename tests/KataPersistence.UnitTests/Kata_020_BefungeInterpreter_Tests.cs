using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace KataExercises.UnitTests;

[TestFixture]
public class Kata_020_BefungeInterpreter_Tests
{
    [Test]
    public void Tests()
    {
        Assert.AreEqual(
                "123456789",
                new Kata_020_BefungeInterpreter().Interpret(">987v>.v\nv456<  :\n>321 ^ _@"));
    }

    [Test]
    public void HelloWorld()
    {
        Assert.AreEqual(
            "40320",
            new Kata_020_BefungeInterpreter().Interpret("08>:1-:v v *_$.@ \n  ^ _$>\\:^^_$>\\:^"));
    }
}
