using NativeZipTools.Core.Models;

namespace NativeZipTools.Core.Interfaces;

public interface IArchiveEngine
{
    void Compress(
        IEnumerable<string> sourcePaths,
        string outputPath,
        string? password = null);

    void Decompress(
        string sourcePath,
        string outputPath,
        string? password = null);

    IReadOnlyList<string> ListContents(
        string archivePath,
        string? password = null);

    ArchiveMetadata GetMetadata(
        string archivePath,
        string? password = null);

    bool VerifyIntegrity(
        string archivePath,
        string? password = null);
}