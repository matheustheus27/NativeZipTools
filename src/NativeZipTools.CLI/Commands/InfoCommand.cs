using NativeZipTools.CLI.Parsing;
using NativeZipTools.Core.Interfaces;

namespace NativeZipTools.CLI.Commands;

public static class InfoCommand
{
    public static void Execute(
        IArchiveEngine engine,
        CommandOptions options)
    {
        var metadata =
            engine.GetMetadata(
                options.SourceFile!,
                options.Password);

        Console.WriteLine($"Name: {metadata.Name}");
        Console.WriteLine($"Format: {metadata.Format}");
        Console.WriteLine($"Compressed Size: {metadata.CompressedSize}");
        Console.WriteLine($"Created: {metadata.CreatedAt}");
    }
}