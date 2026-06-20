using NativeZipTools.CLI.Parsing;
using NativeZipTools.Core.Interfaces;

namespace NativeZipTools.CLI.Commands;

public static class ListCommand
{
    public static void Execute(
        IArchiveEngine engine,
        CommandOptions options)
    {
        var files =
            engine.ListContents(
                options.SourceFile!,
                options.Password);

        foreach (string file in files)
        {
            Console.WriteLine(file);
        }
    }
}