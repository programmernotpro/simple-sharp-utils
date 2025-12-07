using NUnit.Framework;
using IOFile = System.IO.File;
using UtilsFile = FileUtils.File;
using System.Linq;

namespace SimpleSharpUtils.Tests
{
    public class FileTests
    {
        [Test]
        public void ReadAll_Returns_Full_File_Text()
        {
            // Trim because implementation may include trailing newlines
            string result = UtilsFile.ReadAll(TestFilesConfig.HelloFile).Trim();

            Assert.That(result, Is.EqualTo("Hello there! I am a test file!"));
        }

        [Test]
        public void Read_Returns_First_2_Lines_When_File_Has_Single_Line()
        {
            // The file has a single line; Read(..., 0, 2) should return that line + trailing newline
            string result = UtilsFile.Read(TestFilesConfig.HelloFile, 0, 2);

            Assert.That(result, Is.EqualTo("Hello there! I am a test file!\n"));
        }

        [Test]
        public void GetFormattedSize_Returns_NonEmpty()
        {
            string result = UtilsFile.GetFormattedSize(TestFilesConfig.HelloFile);

            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Any(char.IsDigit) && result.Any(char.IsLetter), Is.True);
        }

        [Test]
        public void GetSize_Returns_Positive_Number()
        {
            decimal result = UtilsFile.GetSize(TestFilesConfig.HelloFile);

            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void CountWords_Returns_Seven_For_HelloFile()
        {
            long result = UtilsFile.CountWords(TestFilesConfig.HelloFile);

            // "Hello there! I am a test file!" -> 7 space-separated tokens
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void GetExtension_Returns_DotTxt()
        {
            string ext = UtilsFile.GetExtension(TestFilesConfig.HelloFile);

            Assert.That(ext, Is.EqualTo(".txt"));
        }
    }
}
