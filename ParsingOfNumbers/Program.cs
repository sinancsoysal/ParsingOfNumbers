using ParsingOfNumbers.lib;
using System;

namespace ParsingOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid args");
                return;
            }

            var command = args[0];

            switch (command)
            {
                case "parse" when args.Length == 2:
                case "-p" when args.Length == 2:
                    Parse(args[1]);
                    break;
                case "help":
                case "-h":
                    Help();
                    break;
                default:
                    Console.WriteLine("Invalid command, see help for available commands");
                    break;
            }
        }

        static void Parse(string text)
        {
            if (string.IsNullOrEmpty(text)) Console.WriteLine("Invalid argument: Empty text");
            string converted = ConvertToNumbers.ParseNumbers(text);
            Console.WriteLine("Result: {0}", converted);
        }

        static void Help()
        {
            Console.WriteLine("HELP:\n");
            Console.WriteLine("This program accepts as input an arbitrary text,\n" +
                "and outputs the same text but with all numbers that were spelled in words replaced by the equivalent numbers");
            Console.WriteLine("\nUSAGE:\n");
            Console.WriteLine("ParsingOfNumbers.exe -p \"<string>\"");
        }
    }
}