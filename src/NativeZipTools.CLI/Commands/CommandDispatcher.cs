using NativeZipTools.CLI.Commands;
using NativeZipTools.CLI.Parsing;
using NativeZipTools.Core.Interfaces;

namespace NativeZipTools.CLI;

public sealed class CommandDispatcher
{
    private readonly IArchiveEngine _engine;

    public CommandDispatcher(IArchiveEngine engine)
    {
        _engine = engine;
    }

    public void Execute(string[] args)
    {
        var options = ArgumentParser.Parse(args);

        switch (options.Command.ToLowerInvariant())
        {
            case "compress":
                CompressCommand.Execute(_engine, options);
                break;

            case "extract":
                ExtractCommand.Execute(_engine, options);
                break;

            case "help":
            default:
                HelpCommand.Execute();
                break;
        }
    }
}