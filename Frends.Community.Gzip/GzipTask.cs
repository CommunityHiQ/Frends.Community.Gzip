using System.IO;
using System.IO.Compression;

#pragma warning disable 1591 // Missing XML comment for publicly visible type or member

namespace Frends.Community.Gzip
{
    public class GzipTasks
    {

        /// <summary>
        /// Create gzip archive. 
        /// </summary>
        /// <param name="sourceFullPath">Full path of the input file</param>
        /// <param name="outputFullPath">Full path of the gzip file</param>
        /// <returns>string outputFilePath</returns>
        public static string CreateArchive(string sourceFullPath, string outputFullPath)
        {
            using (FileStream originalFileStream = new FileStream(sourceFullPath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream compressedFileStream = File.Create(outputFullPath))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);

                    }
                }
            }
            return outputFullPath;
        }

        /// <summary>
        /// Extract gzip archive. 
        /// </summary>
        /// <param name="sourceFullPath">Full path of the gzip file</param>
        /// <param name="outputFullPath">Full path of the ouput file</param>
        /// <returns>string outputFilePath</returns>
        public static string ExtractArchive(string sourceFullPath, string outputFullPath)
        {
            using (FileStream compressedFileStream = new FileStream(sourceFullPath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream outputFileStream = File.Create(outputFullPath))
                {
                    using (GZipStream decompressionStream = new GZipStream(compressedFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(outputFileStream);
                    }
                }
            }
            return outputFullPath;
        }

    }
}
