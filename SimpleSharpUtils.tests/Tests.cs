using SimpleSharpUtils;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    //Test for .Reverse()
    public void ReverseTest() {

        string expected = "olleh";
        {
            Assert.That(expected,Is.EqualTo("hello".Reverse()));
        }
    }

    //Test for factorial
    public void FactorialTest()
    {
        int expected = 120;
        
        Assert.That(expected,Is.EqualTo(IntUtilities.Factorial(120)));
    } 
}
