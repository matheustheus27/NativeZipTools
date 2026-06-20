using NativeZipTools.Core.Resources;

namespace NativeZipTools.CLI.Commands;

public static class HelpCommand
{
    public static void Execute()
    {
        Console.WriteLine(Messages.HelpHeader);
        Console.WriteLine();

        Console.WriteLine("compress");
        Console.WriteLine($"  {Messages.HelpCompress}");

        Console.WriteLine();

        Console.WriteLine("extract");
        Console.WriteLine($"  {Messages.HelpExtract}");

        Console.WriteLine();

        Console.WriteLine("list");
        Console.WriteLine($"  {Messages.HelpList}");

        Console.WriteLine();

        Console.WriteLine("verify");
        Console.WriteLine($"  {Messages.HelpVerify}");

        Console.WriteLine();

        Console.WriteLine("info");
        Console.WriteLine($"  {Messages.HelpInfo}");

        Console.WriteLine();

        Console.WriteLine("Examples:");

        Console.WriteLine("  nzip compress -i \"file.txt\" -o \"backup.nip\"");

        Console.WriteLine("  nzip extract -f \"backup.nip\" -d \"./output\"");
    }
}