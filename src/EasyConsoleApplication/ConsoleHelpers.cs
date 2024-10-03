using EasyConsoleApplication.Menus;
using System;

namespace EasyConsoleApplication
{
	/// <summary>
	/// A helper class for console operations.
	/// </summary>
	public static class ConsoleHelpers
	{
		/// <summary>
		/// Writes a message to the console with the specified color.
		/// </summary>
		/// <param name="color">The color of the message.</param>
		/// <param name="message">The message to write.</param>
		/// <param name="newLine">Indicates whether to append a new line after the message. Default is true.</param>
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

		/// <summary>
		/// Writes a message to the console with green color.
		/// </summary>
		/// <param name="message">The message to write.</param>
		/// <param name="newLine">Indicates whether to append a new line after the message. Default is true.</param>
		public static void WriteGreen(string message, bool newLine = true)
		{
			Write(ConsoleColor.Green, message, newLine);
		}

		/// <summary>
		/// Writes a message to the console with yellow color.
		/// </summary>
		/// <param name="message">The message to write.</param>
		/// <param name="newLine">Indicates whether to append a new line after the message. Default is true.</param>
		public static void WriteYellow(string message, bool newLine = true)
		{
			Write(ConsoleColor.Yellow, message, newLine);
		}

		/// <summary>
		/// Writes a message to the console with red color.
		/// </summary>
		/// <param name="message">The message to write.</param>
		/// <param name="newLine">Indicates whether to append a new line after the message. Default is true.</param>
		public static void WriteRed(string message, bool newLine = true)
		{
			Write(ConsoleColor.Red, message, newLine);
		}

		/// <summary>
		/// Asks the user a yes/no question and returns the key info.
		/// </summary>
		/// <param name="color">The color of the question.</param>
		/// <param name="question">The question to ask.</param>
		/// <param name="newLine">Indicates whether to append a new line after the question. Default is true.</param>
		/// <returns>The key info representing the user's response.</returns>
		public static ConsoleKeyInfo AskToUserYesNoQuestion(ConsoleColor color, string question, bool newLine = true)
		{
			Write(color, question + " [y/n] ", false);
			var key = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
			while (key.KeyChar != 'y' && key.KeyChar != 'n')
			{
				key = Console.ReadKey();
			}
			if (newLine)
			{
				Console.WriteLine();
			}
			return key;
		}

		/// <summary>
		/// Reads a line of input from the console with the specified color.
		/// </summary>
		/// <param name="color">The color of the input message.</param>
		/// <param name="message">The input message to display.</param>
		/// <param name="defaultValue">The default value to return if the input is empty or whitespace. Default is null.</param>
		/// <returns>The input string or the default value if the input is empty or whitespace.</returns>
		public static string? ReadLine(ConsoleColor color, string message, string? defaultValue = null)
		{
			Write(color, message, false);
			var input = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(input))
			{
				return defaultValue;
			}
			return input;
		}

		/// <summary>
		/// Waits for the user to hit the 'Enter' key to continue.
		/// </summary>
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
