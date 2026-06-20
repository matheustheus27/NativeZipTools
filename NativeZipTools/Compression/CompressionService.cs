using System.IO.Compression;

namespace NativeZipTools.Compression
{
    public static class CompressionService
    {
        public static void CompressDirectory(
            string source,
            string destination)
        {
            ZipFile.CreateFromDirectory(
                source,
                destination,
                CompressionLevel.Optimal,
                true);
        }
    }
}