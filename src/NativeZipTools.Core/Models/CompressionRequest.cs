namespace NativeZipTools.Core.Models;

public sealed class CompressionRequest
{
    public List<string> InputFiles { get; init; } = [];

    public string OutputFile { get; init; } = string.Empty;

    public string? Password { get; init; }

    public bool EncryptFileNames { get; init; } = true;

    public bool SplitArchive { get; init; }

    public long SplitSizeBytes { get; init; }
}