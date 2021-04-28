using EasyConsoleApplication.Menus;
using System;

namespace EasyConsoleApplication
{
    public static class ConsoleHelpers
    {
        public static void Write(ConsoleColor color, string message, bool newLine = true)
        {
            var originalConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            if (newLine)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write(message);
            }
            Console.ForegroundColor = originalConsoleColor;
        }

        public static void WriteGreen(string message, bool newLine = true)
        {
            Write(ConsoleColor.Green, message, newLine);
        }

        public static void WriteYellow(string message, bool newLine = true)
        {
            Write(ConsoleColor.Yellow, message, newLine);
        }

        public static void WriteRed(string message, bool newLine = true)
        {
            Write(ConsoleColor.Red, message, newLine);
        }

        public static ConsoleKeyInfo AskToUserYesNoQuestion(ConsoleColor color, string question)
        {
            Write(color, question + " [y/n] ", false);
            var key = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
            while (key.KeyChar != 'y' && key.KeyChar != 'n')
            {
                key = Console.ReadKey();
            }
            return key;
        }

        public static string? Readline(ConsoleColor color, string message, string? defaultValue = null)
        {
            Write(color, message, false);
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                return defaultValue;
            }
            return input;
        }

        public static void HitEnterToContinue()
        {
            Write(ConsoleSettings.HitEnterToContinueColor, "Hit 'Enter' to continue.", newLine: true);
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            }
            while (key.Key != ConsoleKey.Enter);
        }
    }
}
