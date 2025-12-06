using FileUtils;
using NUnit.Framework.Internal.Execution;

public class Tests
{
    //Path of the file that is going to be tested with all methods. 
    string path = @"C:\Users\anton\Desktop\simpleSharpUtils\SimpleSharpUtils.tests\testFiles\hello.txt";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void WordCountTest() {

        int expected = 7;

        Assert.That(FileUtils.File.CountWords(path),Is.EqualTo(expected));
    }

    [Test]
    public void SizeTest()
    {
        decimal expected = 0.03m;
        
        Assert.That(FileUtils.File.GetSize(path),Is.EqualTo(expected));
    } 

    [Test]
    public void FormattedSizeTest()
    {
        string expected = "30B";

        Assert.That(FileUtils.File.GetFormattedSize(path),Is.EqualTo(expected));
    }

    [Test]
    public void ReadTest()
    {
        string expected = "Hello there! I am a test file!\n";

        Assert.That(FileUtils.File.Read(path),Is.EqualTo(expected));
    }

    [Test]
    public void ReadAllTest()
    {
        string expected = "Hello there! I am a test file!\n";

        Assert.That(FileUtils.File.ReadAll(path),Is.EqualTo(expected));
    }
}
