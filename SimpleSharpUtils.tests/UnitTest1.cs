using SimpleSharpUtils;
using NUnit.Framework.Legacy;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    //Test for .Reverse()
    public void Test1() {

        string expected = "hello";
        {
            Assert.That(expected,Is.EqualTo(Utilities.Reverse("hello")));
        }
    }
}
