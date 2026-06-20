using System;

namespace NativeZipTools
{
    public static class CommandLineProcessor
    {
        public static void Process(string[] args)
        {
            switch(args[0].ToLower())
            {
                case "compress":
                    Console.WriteLine("Compress command");
                    break;

                case "extract":
                    Console.WriteLine("Extract command");
                    break;

                case "list":
                    Console.WriteLine("List command");
                    break;

                case "info":
                    Console.WriteLine("Info command");
                    break;

                case "verify":
                    Console.WriteLine("Verify command");
                    break;

                default:
                    ShowHelp();
                    break;
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine("Native ZIP Tools");
            Console.WriteLine();
            Console.WriteLine("Commands:");
            Console.WriteLine(" compress");
            Console.WriteLine(" extract");
            Console.WriteLine(" list");
            Console.WriteLine(" info");
            Console.WriteLine(" verify");
        }
    }
}