using NativeZipTools.CLI.Parsing;
using NativeZipTools.Core.Interfaces;

namespace NativeZipTools.CLI.Commands;

public static class VerifyCommand
{
    public static void Execute(
        IArchiveEngine engine,
        CommandOptions options)
    {
        bool result =
            engine.VerifyIntegrity(
                options.SourceFile!,
                options.Password);

        Console.WriteLine(
            result
                ? "Archive is valid."
                : "Archive is corrupted.");
    }
}