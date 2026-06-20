using NativeZipTools.CLI.Parsing;
using NativeZipTools.Core.Interfaces;
using NativeZipTools.Core.Resources;

namespace NativeZipTools.CLI.Commands;

public static class CompressCommand
{
    public static void Execute(
        IArchiveEngine engine,
        CommandOptions options)
    {
        if (options.InputFiles.Count == 0)
        {
            Console.WriteLine("No input file specified.");
            return;
        }

        if (string.IsNullOrWhiteSpace(options.OutputFile))
        {
            Console.WriteLine("No output archive specified.");
            return;
        }

        Console.WriteLine(Messages.Compressing);

        engine.Compress(
            options.InputFiles,
            options.OutputFile,
            options.Password);

        Console.WriteLine(Messages.Completed);
    }
}