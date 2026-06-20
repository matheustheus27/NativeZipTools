namespace NativeZipTools.CLI.Parsing;

public static class ArgumentParser
{
    public static CommandOptions Parse(string[] args)
    {
        var options = new CommandOptions();

        if (args.Length == 0)
            return options;

        options.Command = args[0];

        for (int index = 1; index < args.Length; index++)
        {
            switch (args[index].ToLowerInvariant())
            {
                case "-i":
                    if (index + 1 < args.Length)
                        options.InputFiles.Add(args[++index]);
                    break;

                case "-o":
                    if (index + 1 < args.Length)
                        options.OutputFile = args[++index];
                    break;

                case "-f":
                    if (index + 1 < args.Length)
                        options.SourceFile = args[++index];
                    break;

                case "-d":
                    if (index + 1 < args.Length)
                        options.DestinationDirectory = args[++index];
                    break;

                case "-p":
                    if (index + 1 < args.Length)
                        options.Password = args[++index];
                    break;
            }
        }

        return options;
    }
}