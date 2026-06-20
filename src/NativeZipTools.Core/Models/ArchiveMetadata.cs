namespace NativeZipTools.Core.Models;

public sealed class ArchiveMetadata
{
    public string Name { get; init; } = string.Empty;

    public string Format { get; init; } = string.Empty;

    public string CompressionMethod { get; init; } = string.Empty;

    public bool IsEncrypted { get; init; }

    public long OriginalSize { get; init; }

    public long CompressedSize { get; init; }

    public int FileCount { get; init; }

    public DateTime CreatedAt { get; init; }
}