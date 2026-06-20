namespace NativeZipTools.Core.Interfaces;

/// <summary>
/// Defines the core contract for compression engines within the NativeZipTools ecosystem.
/// </summary>
public interface ICompressionEngine
{
    void Compress(string sourcePath, string outputPath, string? password = null);
    void Decompress(string sourcePath, string outputPath, string? password = null);
}