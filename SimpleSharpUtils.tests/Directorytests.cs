using NUnit.Framework;
using FileUtils;
using System.IO;

namespace SimpleSharpUtils.Tests
{
    public class DirectoryTests
    {
        [Test]
        public void GetFilesNumber_Returns_File_Count()
        {
            int count = FileUtils.Directory.GetFilesNumber(TestFilesConfig.BaseDir);

            Assert.That(count, Is.AtLeast(1), "hello.txt should be in directory");
        }

        [Test]
        public void GetFiles_Returns_Array()
        {
            string[] files = FileUtils.Directory.GetFiles(TestFilesConfig.BaseDir);

            Assert.That(files.Length, Is.GreaterThan(0));
        }

        [Test]
        public void GetFiles_First1_Returns_Single_File()
        {
            string[] files = FileUtils.Directory.GetFiles(TestFilesConfig.BaseDir, 1);

            Assert.That(files.Length, Is.EqualTo(1));
        }

        [Test]
        public void GetFilesMulti_Returns_Dict_With_Valid_Entry()
        {
            var result = FileUtils.Directory.GetFilesMulti(new[] { TestFilesConfig.BaseDir });

            Assert.That(result.ContainsKey(TestFilesConfig.BaseDir), Is.True);
            Assert.That(result[TestFilesConfig.BaseDir].Length, Is.GreaterThan(0));
        }

        [Test]
        public void GetFilesNumberMulti_Returns_Correct_Total()
        {
            long total = FileUtils.Directory.GetFilesNumberMulti(new[] { TestFilesConfig.BaseDir });

            Assert.That(total, Is.GreaterThan(0));
        }
    }
}
