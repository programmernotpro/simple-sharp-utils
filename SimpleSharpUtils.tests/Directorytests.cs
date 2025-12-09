using NUnit.Framework;
using FileUtils;
using System.IO;
using NUnit.Framework.Internal.Execution;
using NUnit.Framework.Internal;

namespace SimpleSharpUtils.Tests
{
    public class DirectoryTests
    {
        [Test]
        public static void GetFilesNumberTest()
        {
            int expected = 2;
            Assert.That(UtilsDirectory.GetFilesNumber(TestFilesConfig.BaseDir), Is.EqualTo(expected));
        

        }
        [Test]
        public static void GetFilesTest()
        {
            string[] expected = [".md",".txt"];
            Assert.That(UtilsDirectory.GetExtensions(TestFilesConfig.BaseDir), Is.EqualTo(expected));   
        }

        [Test]
        public static void GetDirSize()
        {
            Assert.That(UtilsDirectory.GetDirSize(TestFilesConfig.BaseDir), Is.LessThan(0.5));
        }

        [Test]
        public static void HasFileTest()
        {
            Assert.That(UtilsDirectory.HasFile(TestFilesConfig.BaseDir,"hello.txt"), Is.EqualTo(true));
        }

        [Test]
        public static void GetLargestFileTest()
        {
            Assert.That(UtilsDirectory.GetLargestFile(TestFilesConfig.BaseDir), Is.EqualTo("hello.md"));
        }

        [Test]
        public static void GetSmallestFileTest()
        {
            Assert.That(UtilsDirectory.GetSmallestFile(TestFilesConfig.BaseDir), Is.EqualTo("hello.txt"));
        }
    }
}
