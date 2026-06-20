using NativeZipTools.CLI.Parsing;
using NativeZipTools.Core.Interfaces;
using NativeZipTools.Core.Resources;

namespace NativeZipTools.CLI.Commands;

public static class ExtractCommand
{
    public static void Execute(
        IArchiveEngine engine,
        CommandOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.SourceFile))
        {
            Console.WriteLine("No archive file specified.");
            return;
        }

        if (string.IsNullOrWhiteSpace(options.DestinationDirectory))
        {
            Console.WriteLine("No destination directory specified.");
            return;
        }

        Console.WriteLine(Messages.Extracting);

        engine.Decompress(
            options.SourceFile,
            options.DestinationDirectory,
            options.Password);

        Console.WriteLine(Messages.Completed);
    }
}