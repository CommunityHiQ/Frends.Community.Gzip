using NUnit.Framework;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Frends.Community.Gzip.Tests
{

    [TestFixture]
    public class GzipTests
    {

        private static readonly string _basePath = Path.Combine(Path.GetTempPath(), "Frends.Community.GZip.Tests");
        private static readonly string _inputFileName = "test.txt";
        private static readonly string _refFileName = "testiref.txt.gz";
        private static readonly string _gzipFileName = "test_output.txt.gz";
        private static readonly string _outputFileName = "test_output.txt";

        private static string _refFileHash;
        private static string _inputFileHash;


        [TearDown]
        public void TearDown()
        {
            // remove test directories and files
            Directory.Delete(_basePath, true);
        }

        [SetUp]
        public void SetupTests()
        {
            // create source directoty and files
            Directory.CreateDirectory(_basePath);

            File.WriteAllText(Path.Combine(_basePath, _inputFileName), "The quick brown fox jumps over the lazy dog");
            _inputFileHash = MD5Hash(Path.Combine(_basePath, _inputFileName));

            File.WriteAllBytes(Path.Combine(_basePath, _refFileName), Convert.FromBase64String("H4sIAAAAAAAACgvJSFUoLM1MzlZIKsovz1NIy69QyCrNLShWyC9LLVIoAUrnJFZVKqTkpwMAOaNPQSsAAAA="));
            _refFileHash = MD5Hash(Path.Combine(_basePath, _refFileName));
        }

        [Test]
        public void CreateArchive()
        {
            string outputFileName = Path.Combine(_basePath, _gzipFileName);
            Frends.Community.Gzip.GzipTasks.CreateArchive(Path.Combine(_basePath, _inputFileName), outputFileName);

            string hash = MD5Hash(outputFileName);

            Assert.AreEqual(_refFileHash, hash);

        }


        [Test]
        public void ExtractArchive()
        {
            string outputFileName = Path.Combine(_basePath, _outputFileName);

            string gzipFileName = Path.Combine(_basePath, _gzipFileName);
            if (!File.Exists(gzipFileName))
            {
                CreateArchive();
            }

            Frends.Community.Gzip.GzipTasks.ExtractArchive(gzipFileName, outputFileName);
            string hash = MD5Hash(outputFileName);

            Assert.AreEqual(_inputFileHash, hash);

        }

        /// <summary>
        /// Read file and compute MD5 hash
        /// Using MD5 because it is short and it is enough unique
        /// </summary>
        /// <param name="filename">Full path to file</param>
        /// <returns>MD5 hash</returns>
        public static string MD5Hash(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }
        }

    }
}