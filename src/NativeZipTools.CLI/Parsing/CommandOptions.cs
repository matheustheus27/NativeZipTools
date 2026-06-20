namespace NativeZipTools.CLI.Parsing;

public sealed class CommandOptions
{
    public string Command { get; set; } = string.Empty;

    public List<string> InputFiles { get; } = [];

    public string? OutputFile { get; set; }

    public string? SourceFile { get; set; }

    public string? DestinationDirectory { get; set; }

    public string? Password { get; set; }
}